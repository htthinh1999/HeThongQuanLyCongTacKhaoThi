using HeThongQuanLyCongTacKhaoThi.Models;
using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace HeThongQuanLyCongTacKhaoThi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountApiClient _accountApiClient;
        private readonly IConfiguration _configuration;
        private readonly ISubjectApiClient _subjectApiClient;

        public HomeController(ILogger<HomeController> logger,
            IAccountApiClient accountApiClient,
            IConfiguration configuration,
            ISubjectApiClient subjectApiClient)
        {
            _logger = logger;
            _accountApiClient = accountApiClient;
            _configuration = configuration;
            _subjectApiClient = subjectApiClient;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.Name == null)
            {
                return View();
            }

            string userID = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;
            HttpContext.Session.SetString("UserID", userID);
            HttpContext.Session.SetString("UserFullName", (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.GivenName).Value);

            // Get student' subject
            var getSubjectsByAccountID = await _subjectApiClient.GetSubjectsByAccountID(new Guid(userID));
            var subjects = getSubjectsByAccountID.ResultObj;
            HttpContext.Session.SetString("AccoutSubjects", JsonConvert.SerializeObject(subjects));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _accountApiClient.Authenticate(request);

            if (result.ResultObj == null)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }

            var accountPrincipal = ValidateToken(result.ResultObj);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddYears(10),
                IsPersistent = true,
                //AllowRefresh = true
            };

            HttpContext.Session.SetString("Token", result.ResultObj);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                accountPrincipal,
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}
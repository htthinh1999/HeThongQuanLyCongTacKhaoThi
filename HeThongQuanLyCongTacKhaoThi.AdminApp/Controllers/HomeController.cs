using HeThongQuanLyCongTacKhaoThi.AdminApp.Models;
using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountApiClient _accountApiClient;

        public HomeController(ILogger<HomeController> logger, IAccountApiClient accountApiClient)
        {
            _logger = logger;
            _accountApiClient = accountApiClient;
        }

        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                return RedirectToAction("Login", "Account");
            }
            var getUser = await _accountApiClient.GetByUserName(User.Identity.Name);

            if(getUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = getUser.ResultObj;
            (User.Identity as ClaimsIdentity).AddClaim(new Claim("FullName", user.Name));
            HttpContext.Session.SetString("UserFullName", user.Name);

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
    }
}
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.System.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<RoleAccount> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<Account> userManager, SignInManager<Account> signInManager, RoleManager<RoleAccount> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)   return null;
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Issuer"],
                claims,
                expires: DateTime.Now,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new Account()
            {
                UserName = request.Username,
                Name = request.Name,
                Gender = request.Gender,
                Birthday = request.Birthday,
                Email = request.Email,
                Student_TeacherID = request.Student_TeacherID,
                ClassID = request.ClassID,
                Address = request.Address
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<PagedResult<AccountViewModel>> GetAccountPaging(GetAccountPagingRequest request)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(
                    x => x.UserName.Contains(request.Keyword)
                        || x.Name.Contains(request.Keyword)
                        || x.Birthday.ToString().Contains(request.Keyword)
                        || x.Email.Contains(request.Keyword)
                        || (x.Gender == request.Keyword.Equals("Nam"))
                        || x.PhoneNumber.Contains(request.Keyword)
                    );
            }

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new AccountViewModel()
            {
                Username = x.UserName,
                Name = x.Name,
                Email = x.Email,
                Birthday = x.Birthday,
                Gender = x.Gender,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<AccountViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}

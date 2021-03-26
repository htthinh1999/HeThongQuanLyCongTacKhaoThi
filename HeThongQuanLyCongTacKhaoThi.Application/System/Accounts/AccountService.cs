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

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return new ApiErrorResult<string>("Tên tài khoản hoặc mật khẩu không đúng");
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Tên tài khoản hoặc mật khẩu không đúng");
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

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByLoginAsync("", request.Username);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Lỗi trùng tên đăng nhập");
            }

            if(await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Lỗi trùng địa chỉ email");
            }

            user = new Account()
            {
                UserName = request.Username,
                Name = request.Name,
                Gender = request.Gender,
                Birthday = request.Birthday,
                Email = request.Email,
                Student_TeacherID = request.Student_TeacherID,
                ClassID = request.ClassID,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<PagedResult<AccountViewModel>>> GetAccountPaging(GetAccountPagingRequest request)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(
                    x => x.UserName.Contains(request.Keyword)
                        || x.Name.Contains(request.Keyword)
                        || x.Birthday.ToString().Contains(request.Keyword)
                        || x.Email.Contains(request.Keyword)
                        || ((request.Keyword.Equals("Nam") || request.Keyword.Equals("Nữ")) && (x.Gender == request.Keyword.Equals("Nam")))
                        || x.PhoneNumber.Contains(request.Keyword)
                        || x.ClassID.Contains(request.Keyword)
                        || x.Student_TeacherID.Contains(request.Keyword)
                        || x.Address.Contains(request.Keyword)
                    );
            }

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new AccountViewModel()
            {
                Id = x.Id,
                Username = x.UserName,
                Name = x.Name,
                Email = x.Email,
                Birthday = x.Birthday,
                Gender = x.Gender,
                PhoneNumber = x.PhoneNumber,
                Student_TeacherID = x.Student_TeacherID,
                Address = x.Address,
                ClassID = x.ClassID
            }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<AccountViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<AccountViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Update(Guid id, AccountUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Lỗi trùng tên đăng nhập");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());

            user.Name = request.Name;
            user.Email = request.Email;
            user.Gender = request.Gender;
            user.Birthday = request.Birthday;
            user.Student_TeacherID = request.Student_TeacherID;
            user.ClassID = request.ClassID;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return new ApiErrorResult<bool>("Không tìm thấy tài khoản");
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Không thể xoá tài khoản");
        }

        public async Task<ApiResult<AccountViewModel>> GetByID(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null)
            {
                return new ApiErrorResult<AccountViewModel>("Tài khoản không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var accountViewModel = new AccountViewModel()
            {
                Id = id,
                Email = user.Email,
                Birthday = user.Birthday,
                Gender = user.Gender,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName,
                Student_TeacherID = user.Student_TeacherID,
                Address = user.Address,
                ClassID = user.ClassID,
                Roles = roles
            };
            return new ApiSuccessResult<AccountViewModel>(accountViewModel);
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }

            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }

            var addedRoles = request.Roles.Where(x => x.Selected == true).Select(x => x.Name).ToList();
            foreach(var roleName in addedRoles)
            {
                if(await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }
    }
}

using HeThongQuanLyCongTacKhaoThi.Application.System.Accounts;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Authorize(Policy = Policy.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var resultToken = await _accountService.Authenticate(request);
            //if (!resultToken.IsSuccessed)
            //{
            //    return BadRequest(resultToken.Message);
            //}
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _accountService.Register(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AccountUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _accountService.Delete(id);
            return Ok(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetAccountPagingRequest request)
        {
            var result = await _accountService.GetAccountPaging(request);
            return Ok(result);
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(Guid id)
        {
            var result = await _accountService.GetByID(id);
            return Ok(result);
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var result = await _accountService.GetByUserName(username);
            return Ok(result);
        }

        [HttpGet("get-all-teachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _accountService.GetAllTeachers();
            return Ok(result);
        }
    }
}
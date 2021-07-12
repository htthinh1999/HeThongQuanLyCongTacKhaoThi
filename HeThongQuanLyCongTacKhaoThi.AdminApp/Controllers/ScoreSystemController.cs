using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class ScoreSystemController : Controller
    {
        private readonly IResultApiClient _resultApiClient;

        public ScoreSystemController(IResultApiClient resultApiClient)
        {
            _resultApiClient = resultApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var teacherID = User.IsInRole(Roles.Admin)? Guid.Empty: new Guid(HttpContext.Session.GetString("UserID"));
            var getScoreList = await _resultApiClient.GetScoreList(teacherID);

            if(!getScoreList.IsSuccessed)
            {
                return BadRequest(getScoreList.Message);
            }

            return View(getScoreList.ResultObj);
        }
    }
}

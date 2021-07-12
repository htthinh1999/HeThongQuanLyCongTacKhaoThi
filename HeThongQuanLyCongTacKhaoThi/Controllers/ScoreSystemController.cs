using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.WebApp.Controllers
{
    [Authorize(Policy = Policy.Student)]
    public class ScoreSystemController : Controller
    {
        private readonly IResultApiClient _resultApiClient;

        public ScoreSystemController(IResultApiClient resultApiClient)
        {
            _resultApiClient = resultApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var studentID = new Guid(HttpContext.Session.GetString("UserID"));
            var getScoreListByStudentID = await _resultApiClient.GetScoreListByStudentID(studentID);

            if (!getScoreListByStudentID.IsSuccessed)
            {
                return BadRequest(getScoreListByStudentID.Message);
            }

            return View(getScoreListByStudentID.ResultObj);
        }
    }
}

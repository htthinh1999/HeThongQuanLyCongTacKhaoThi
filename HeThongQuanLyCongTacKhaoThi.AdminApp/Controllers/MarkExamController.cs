using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    public class MarkExamController : Controller
    {
        private readonly IResultApiClient _resultApiClient;

        public MarkExamController(IResultApiClient resultApiClient)
        {
            _resultApiClient = resultApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var teacherID = new Guid(HttpContext.Session.GetString("UserID"));
            var getExamResult = await _resultApiClient.GetExamResult(studentAnswerID: id, teacherID: teacherID);

            var examResult = getExamResult.ResultObj;

            return View(examResult);
        }


    }
}

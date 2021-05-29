using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
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

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var teacherID = new Guid(HttpContext.Session.GetString("UserID"));
            var request = new GetExamResultPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TeacherID = teacherID
            };
            var data = await _resultApiClient.GetExamResultPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            ViewBag.TeacherID = teacherID;
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Mark(Guid id)
        {
            var teacherID = new Guid(HttpContext.Session.GetString("UserID"));
            var getExamResult = await _resultApiClient.GetExamResultToMark(studentAnswerID: id, teacherID: teacherID);

            if (!getExamResult.IsSuccessed)
            {
                return BadRequest(getExamResult.Message);
            }

            var examResult = getExamResult.ResultObj;

            return View(examResult);
        }

        [HttpPost]
        public async Task<IActionResult> Mark(MarkExamRequest request)
        {
            var teacherID = new Guid(HttpContext.Session.GetString("UserID"));

            var result = await _resultApiClient.MarkExam(teacherID, request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }

            return RedirectToAction("Index", "MarkExam");
        }

        /// <summary>
        /// Get student answer was marked
        /// </summary>
        /// <param name="id">Student Answer ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var teacherID = new Guid(HttpContext.Session.GetString("UserID"));
            var getExamResult = await _resultApiClient.GetExamResult(studentAnswerID: id, teacherID: teacherID);

            if (!getExamResult.IsSuccessed)
            {
                return BadRequest(getExamResult.Message);
            }

            var examResult = getExamResult.ResultObj;

            return View(examResult);
        }

    }
}

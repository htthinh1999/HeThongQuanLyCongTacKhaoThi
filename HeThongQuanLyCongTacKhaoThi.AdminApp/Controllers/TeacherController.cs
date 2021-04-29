using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class TeacherController : Controller
    {
        private IAccountApiClient _accountApiClient;
        private ISubjectApiClient _subjectApiClient;

        public TeacherController(IAccountApiClient accountApiClient, ISubjectApiClient subjectApiClient)
        {
            _accountApiClient = accountApiClient;
            _subjectApiClient = subjectApiClient;
        }

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetAccountPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _accountApiClient.GetTeacherPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(data.ResultObj);
        }

        public async Task<IActionResult> TeacherSubjects(Guid teacherID, string teacherName)
        {
            var getTeacherSubjects = await _subjectApiClient.GetSubjectsByAccountID(teacherID);
            if (!getTeacherSubjects.IsSuccessed)
            {
                return BadRequest("Không tìm thấy môn học giảng viên này giảng dạy");
            }

            ViewBag.TeacherName = teacherName;

            return View(getTeacherSubjects.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeacherSubjects(Guid teacherID, string teacherName)
        {
            var getTeacherSubjects = await _subjectApiClient.GetSubjectsByAccountID(teacherID);
            if (!getTeacherSubjects.IsSuccessed)
            {
                return BadRequest("Không tìm thấy môn học giảng viên này giảng dạy");
            }

            ViewBag.TeacherID = teacherID;
            ViewBag.TeacherName = teacherName;

            // Get subjects
            var getSubjects = await _subjectApiClient.GetAll();
            if (!getSubjects.IsSuccessed)
            {
                return BadRequest("Không lấy được danh sách môn học");
            }
            ViewBag.Subjects = getSubjects.ResultObj;

            return View(getTeacherSubjects.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeacherSubjects(Guid teacherID, List<string> subjectIDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Không thể cập nhật môn học giảng dạy cho giảng viên");
            }

            var updateTeacherSubjects = await _subjectApiClient.UpdateTeacherSubjects(teacherID, subjectIDs);
            if (!updateTeacherSubjects.IsSuccessed)
            {
                return BadRequest("Không thể cập nhật môn học giảng dạy cho giảng viên");
            }

            TempData["SuccessMsg"] = "Cập nhật môn học giảng dạy cho giảng viên thành công";
            return RedirectToAction("Index");
        }
    }
}

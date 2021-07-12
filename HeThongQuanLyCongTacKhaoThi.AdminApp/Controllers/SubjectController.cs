using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class SubjectController : Controller
    {
        private readonly ISubjectApiClient _subjectApiClient;

        public SubjectController(ISubjectApiClient subjectApiClient)
        {
            _subjectApiClient = subjectApiClient;
        }

        public async Task<IActionResult> GetAllSubjects(int id)
        {
            var getSubjects = await _subjectApiClient.GetAll();
            var subjects = getSubjects.ResultObj;

            ViewData["Subjects"] = new SelectList(subjects, "ID", "Name");
            return PartialView("_Subjects", id);
        }

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetSubjectPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _subjectApiClient.GetSubjectPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectCURequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _subjectApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["SuccessMsg"] = "Tạo môn học thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _subjectApiClient.GetByID(id);

            if (result.IsSuccessed)
            {
                var subject = result.ResultObj;
                var updateRequest = new SubjectCURequest()
                {
                    ID = subject.ID,
                    Name = subject.Name,
                    LessonCount = subject.LessonCount,
                    CreditCount = subject.CreditCount
                };

                return View(updateRequest);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, SubjectCURequest request)
        {
            var result = await _subjectApiClient.Update(id, request);

            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }

            TempData["SuccessMsg"] = "Cập nhật môn học thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var result = await _subjectApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _subjectApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubjectViewModel request)
        {
            var result = await _subjectApiClient.Delete(request.ID);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }

            TempData["SuccessMsg"] = "Xoá môn học thành công";
            return RedirectToAction("Index");
        }
    }
}

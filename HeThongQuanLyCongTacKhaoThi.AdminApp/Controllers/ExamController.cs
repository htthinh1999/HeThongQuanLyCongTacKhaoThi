using HeThongQuanLyCongTacKhaoThi.AdminApp.Services;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamApiClient _examApiClient;

        public ExamController(IExamApiClient examApiClient)
        {
            _examApiClient = examApiClient;
        }

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetExamPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _examApiClient.GetExamPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var examCreateRequest = new ExamCreateRequest()
            {
                QuestionGroupViewModels = new List<QuestionGroupViewModel>()
            };
            return View(examCreateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamCreateRequest request, List<int> QuestionGroups)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Remove all null item and add to request
            request.QuestionGroups = QuestionGroups.ToList();
            
            var result = await _examApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["SuccessMsg"] = "Tạo đề thi thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _examApiClient.GetByID(id);
            if (result.IsSuccessed)
            {
                var exam = result.ResultObj;
                var updateResquest = new ExamUpdateRequest()
                {
                    ID = exam.ID,
                    Name = exam.Name,
                    ReRandom = false,
                    SubjectID = exam.SubjectID,
                    MultipleChoiceQuestionCount = exam.MultipleChoiceQuestionCount,
                    EssayQuestionCount = exam.EssayQuestionCount,
                    QuestionGroups = exam.QuestionGroups.ToList()
                };

                return View(updateResquest);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExamUpdateRequest request, List<int> QuestionGroups)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            request.QuestionGroups = QuestionGroups.ToList();
            var result = await _examApiClient.Update(request.ID, request);
            
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }

            TempData["SuccessMsg"] = "Cập nhật đề thi thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _examApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _examApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ExamViewModel request)
        {
            var result = await _examApiClient.Delete(request.ID);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }

            TempData["SuccessMsg"] = "Xoá đề thi thành công";
            return RedirectToAction("Index");
        }
    }
}

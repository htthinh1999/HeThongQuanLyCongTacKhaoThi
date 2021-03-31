using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class ExamController : Controller
    {
        private readonly IExamApiClient _examApiClient;
        private readonly ISubjectApiClient _subjectApiClient;

        public ExamController(IExamApiClient examApiClient, ISubjectApiClient subjectApiClient)
        {
            _examApiClient = examApiClient;
            _subjectApiClient = subjectApiClient;
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
        public async Task<IActionResult> Create()
        {
            var examCreateRequest = new ExamCreateRequest()
            {
                QuestionGroupViewModels = new List<QuestionGroupViewModel>()
            };

            // Get subjects
            var getSubjects = await _subjectApiClient.GetAll();
            var subjects = getSubjects.ResultObj;
            examCreateRequest.Subjects = subjects.ToList();

            return View(examCreateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamCreateRequest request, List<int> QuestionGroups)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            if(QuestionGroups.Count == 0)
            {
                return BadRequest("Bạn cần chọn nhóm câu hỏi");
            }

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

                // Get subjects
                var getSubjects = await _subjectApiClient.GetAll();
                var subjects = getSubjects.ResultObj;
                updateResquest.Subjects = subjects.ToList();

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

            if (QuestionGroups.Count == 0)
            {
                return BadRequest("Bạn cần chọn nhóm câu hỏi");
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
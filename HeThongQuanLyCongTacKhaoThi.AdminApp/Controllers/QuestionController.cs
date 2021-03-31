using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class QuestionController : Controller
    {
        private readonly IQuestionApiClient _questionApiClient;

        public QuestionController(IQuestionApiClient questionApiClient)
        {
            _questionApiClient = questionApiClient;
        }

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetQuestionPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _questionApiClient.GetQuestionPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionCURequest request, List<AnswerCURequest> answerCreateUpdateRequests)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Check has min one right answer if question is multiple choice
            if (request.IsMultipleChoice)
            {
                int wrongAnscount = 0;
                foreach (var ans in answerCreateUpdateRequests)
                {
                    if (!ans.IsCorrect)
                    {
                        wrongAnscount++;
                    }
                }

                if (wrongAnscount == answerCreateUpdateRequests.Count)
                {
                    ModelState.AddModelError("", "Bạn cần chọn 1 đáp án đúng");
                    return View(request);
                }
            }

            request.Answers = answerCreateUpdateRequests.ToList();
            var result = await _questionApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["SuccessMsg"] = "Tạo câu hỏi thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _questionApiClient.GetByID(id);
            if (result.IsSuccessed)
            {
                var question = result.ResultObj;
                var updateResquest = new QuestionCURequest()
                {
                    ID = question.ID,
                    SubjectID = question.SubjectID,
                    GroupID = question.GroupID,
                    Content = question.Content,
                    IsMultipleChoice = question.IsMultipleChoice,
                    Answers = question.Answers.ToList()
                };

                return View(updateResquest);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QuestionCURequest request, List<AnswerCURequest> Answers)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Check has min one right answer if question is multiple choice
            if (request.IsMultipleChoice)
            {
                int wrongAnscount = 0;
                foreach (var ans in Answers)
                {
                    if (!ans.IsCorrect)
                    {
                        wrongAnscount++;
                    }
                }

                if (wrongAnscount == Answers.Count)
                {
                    ModelState.AddModelError("", "Bạn cần chọn 1 đáp án đúng");
                    return View(request);
                }
            }

            request.Answers = Answers.ToList();
            var result = await _questionApiClient.Update(request.ID, request);
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }

            if (result.ResultObj)
            {
                return BadRequest(result.Message);
            }

            TempData["SuccessMsg"] = "Cập nhật câu hỏi thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _questionApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _questionApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(QuestionViewModel request)
        {
            var result = await _questionApiClient.Delete(request.ID);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }

            if (result.ResultObj)
            {
                return BadRequest(result.Message);
            }

            TempData["SuccessMsg"] = "Xoá câu hỏi thành công";
            return RedirectToAction("Index");
        }
    }
}
using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class QuestionController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ISubjectApiClient _subjectApiClient;
        private readonly IQuestionGroupApiClient _questionGroupApiClient;
        private readonly IQuestionApiClient _questionApiClient;

        public QuestionController(IQuestionApiClient questionApiClient, ISubjectApiClient subjectApiClient, IQuestionGroupApiClient questionGroupApiClient, IWebHostEnvironment environment)
        {
            _questionApiClient = questionApiClient;
            _subjectApiClient = subjectApiClient;
            _questionGroupApiClient = questionGroupApiClient;
            _environment = environment;
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
        public async Task<IActionResult> Create()
        {
            var question = new QuestionCURequest();

            // Get subjects
            var getSubjects = await _subjectApiClient.GetAll();
            var subjects = getSubjects.ResultObj;
            question.Subjects = subjects.ToList();

            // Get group questions
            var getQuestionGroups = await _questionGroupApiClient.GetAll();
            var questionGroups = getQuestionGroups.ResultObj;
            question.QuestionGroups = questionGroups;

            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionCURequest request, List<AnswerCURequest> answerCreateUpdateRequests, IFormFile ImageAnswer)
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

            // Check ImageAnswer Input
            if (ImageAnswer != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageAnswer.FileName)}";
                var file = Path.Combine(_environment.ContentRootPath, "images", fileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await ImageAnswer.CopyToAsync(fileStream);
                }
                request.Answers.Add(new AnswerCURequest()
                {
                    Content = $"/images/{fileName}",
                    IsCorrect = true
                });
            }

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
                var updateRequest = new QuestionCURequest()
                {
                    ID = question.ID,
                    SubjectID = question.SubjectID,
                    GroupID = question.GroupID,
                    Content = question.Content,
                    IsMultipleChoice = question.IsMultipleChoice,
                    Answers = question.Answers.ToList()
                };

                // Get subjects
                var getSubjects = await _subjectApiClient.GetAll();
                var subjects = getSubjects.ResultObj;
                updateRequest.Subjects = subjects.ToList();

                // Get group questions
                var getQuestionGroups = await _questionGroupApiClient.GetAll();
                var questionGroups = getQuestionGroups.ResultObj;
                updateRequest.QuestionGroups = questionGroups;

                return View(updateRequest);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QuestionCURequest request, List<AnswerCURequest> Answers, IFormFile ImageAnswer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            request.Answers = Answers.ToList();

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

                    // Get subjects
                    var getSubjects = await _subjectApiClient.GetAll();
                    var subjects = getSubjects.ResultObj;
                    request.Subjects = subjects.ToList();

                    // Get group questions
                    var getQuestionGroups = await _questionGroupApiClient.GetAll();
                    var questionGroups = getQuestionGroups.ResultObj;
                    request.QuestionGroups = questionGroups;

                    return View(request);
                }
            }

            // Check ImageAnswer Input
            if (ImageAnswer != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageAnswer.FileName)}";
                var file = Path.Combine(_environment.ContentRootPath, "images", fileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await ImageAnswer.CopyToAsync(fileStream);
                }
                request.Answers.Add(new AnswerCURequest()
                {
                    Content = $"/images/{fileName}",
                    IsCorrect = true
                });
            }

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
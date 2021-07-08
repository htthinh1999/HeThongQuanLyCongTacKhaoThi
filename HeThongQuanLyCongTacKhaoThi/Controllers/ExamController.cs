using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.WebApp.Controllers
{
    [Authorize(Policy = Policy.Student)]
    public class ExamController : Controller
    {
        private readonly IExamApiClient _examApiClient;
        private readonly IStudentAnswerApiClient _studentAnswerApiClient;
        private readonly IResultApiClient _resultApiClient;

        // List to store all question ids of exam
        private static List<int> questionIDs = new List<int>();

        public ExamController(IExamApiClient examApiClient, IStudentAnswerApiClient studentAnswerApiClient, IResultApiClient resultApiClient)
        {
            _examApiClient = examApiClient;
            _studentAnswerApiClient = studentAnswerApiClient;
            _resultApiClient = resultApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int examID)
        {
            var getExam = await _examApiClient.GetByID(examID);
            var exam = getExam.ResultObj;

            if(exam == null)
            {
                return BadRequest("Không thể tìm thấy đề thi");
            }

            if(exam.Contest.StartTime >= DateTime.Now)
            {
                return BadRequest("Bạn chưa thể tham gia thi, thời gian chưa bắt đầu!");
            }

            questionIDs = new List<int>();
            for (int i = 0; i < exam.ExamDetails.Count; i++)
            {
                var question = exam.ExamDetails[i].Question;

                // Store question ID to list and reset question ID follow question index to submit form
                questionIDs.Add(question.ID);
                question.ID = i;
            }

            return View(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ExamViewModel examViewModel, List<string> AnswerOfStudent, List<bool> IsMultipleChoice)
        {
            var currentAccountID = new Guid(HttpContext.Session.GetString("UserID"));

            var studentAnswerCreateRequest = new StudentAnswerCURequest()
            {
                AccountID = currentAccountID,
                ExamID = examViewModel.ID,
                studentAnswerDetails = new List<StudentAnswerDetailCreateRequest>()
            };

            for (int i = 0; i < AnswerOfStudent.Count; i++)
            {
                var studentAnswerDetailCreateRequest = new StudentAnswerDetailCreateRequest()
                {
                    QuestionID = questionIDs[i]
                };

                if (IsMultipleChoice[i])
                {
                    studentAnswerDetailCreateRequest.AnswerID = Convert.ToInt32(AnswerOfStudent[i]);
                }
                else
                {
                    studentAnswerDetailCreateRequest.StudentAnswerContent = AnswerOfStudent[i];
                }

                studentAnswerCreateRequest.studentAnswerDetails.Add(studentAnswerDetailCreateRequest);

            }

            var result = await _studentAnswerApiClient.Create(studentAnswerCreateRequest);

            await _resultApiClient.Create(new ResultCURequest()
            {
                UserID = currentAccountID,
                ExamID = examViewModel.ID,
                SubjectID = examViewModel.SubjectID,
                StudentAnswerID = result.ResultObj,
                ContestID = examViewModel.ContestID
            });

            if (!result.IsSuccessed)
            {
                return BadRequest("Lỗi tạo đáp án học viên");
            }

            return RedirectToAction("Details", "Subject", new { subjectID = examViewModel.SubjectID });
        }


        [HttpGet]
        public async Task<IActionResult> GetResult(int contestID)
        {
            var currentAccountID = new Guid(HttpContext.Session.GetString("UserID"));

            var getExamResult = await _resultApiClient.GetExamResult(accountID: currentAccountID, contestID: contestID);

            var examResult = getExamResult.ResultObj;

            return View(examResult);
        }
    }
}

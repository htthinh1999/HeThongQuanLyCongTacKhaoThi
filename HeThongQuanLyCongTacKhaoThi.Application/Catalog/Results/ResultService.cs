using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using Microsoft.EntityFrameworkCore;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results
{
    public class ResultService : IResultService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public ResultService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(ResultCURequest request)
        {
            var mResult = _context.Results.FirstOrDefault(x => x.UserID == request.UserID && x.ContestID == request.ContestID);

            _context.Results.Add(new Result()
            {
                UserID = request.UserID,
                ContestID = request.ContestID,
                ExamID = request.ExamID,
                SubjectID = request.SubjectID,
                StudentAnswerID = request.StudentAnswerID,
                Time = (mResult == null) ? 1 : 2
            });

            var result = await _context.SaveChangesAsync();
            if(result == 0)
            {
                return new ApiErrorResult<bool>("Không thể tạo kết quả");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid accountID, int contestID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var examResult = await (from rs in _context.Results
                              join e in _context.Exams on rs.ExamID equals e.ID
                              join ed in _context.ExamDetails on e.ID equals ed.ExamID
                              join q in _context.Questions on ed.QuestionID equals q.ID
                              where e.ContestID == contestID && rs.UserID == accountID
                              group new { rs, e, q } by new { rs.StudentAnswerID, e.Name } into exam
                              select new ExamResultViewModel()
                              {
                                  Name = exam.Key.Name,
                                  MultipleChoiceQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                  EssayQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                  StudentAnswerID = exam.Key.StudentAnswerID,
                                  studentAnswerDetails = new List<StudentAnswerDetailViewModel>()
                              }).FirstOrDefaultAsync();

            if(examResult == null)
            {
                return new ApiErrorResult<ExamResultViewModel>("Không thể lấy kết quả đề thi");
            }

            var studentAnswerDetails = await (from stad in _context.StudentAnswerDetails
                                             join q in _context.Questions on stad.QuestionID equals q.ID
                                             where stad.StudentAnswerID == examResult.StudentAnswerID
                                             orderby q.IsMultipleChoice
                                             select new StudentAnswerDetailViewModel()
                                             {
                                                 AnswerID = stad.AnswerID,
                                                 QuestionID = q.ID,
                                                 EssayPath = stad.EssayPath,
                                                 StudentAnswerContent = stad.StudentAnswerContent,
                                                 Teacher1Comment = stad.Teacher1Comment,
                                                 Teacher2Comment = stad.Teacher2Comment,
                                                 Mark1 = stad.Mark1,
                                                 Mark2 = stad.Mark2,
                                                 Mark = stad.Mark,
                                                 Question = new QuestionViewModel()
                                                 {
                                                     ID = q.ID,
                                                     Content = q.Content,
                                                     IsMultipleChoice = q.IsMultipleChoice,
                                                     Answers = new List<AnswerCURequest>()
                                                 }
                                             }).ToListAsync();

            foreach(var studentAnswerDetail in studentAnswerDetails)
            {
                // Get all answers of question
                var answers = await (from a in _context.Answers
                                      where a.QuestionID == studentAnswerDetail.QuestionID
                                      select new AnswerCURequest()
                                      {
                                          ID = a.ID,
                                          QuestionID = a.QuestionID,
                                          Content = a.Content,
                                          IsCorrect = a.IsCorrect
                                      }).ToListAsync();

                studentAnswerDetail.Question.Answers = answers.ToList();
            }
            

            examResult.studentAnswerDetails = studentAnswerDetails.ToList();

            return new ApiSuccessResult<ExamResultViewModel>(examResult);
        }

        public async Task<ApiResult<ExamResultViewModel>> GetExamResult(int studentAnswerID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var examResult = await (from rs in _context.Results
                                    join e in _context.Exams on rs.ExamID equals e.ID
                                    join ed in _context.ExamDetails on e.ID equals ed.ExamID
                                    join q in _context.Questions on ed.QuestionID equals q.ID
                                    where rs.StudentAnswerID == studentAnswerID
                                    group new { rs, e, q } by new { rs.StudentAnswerID, e.Name } into exam
                                    select new ExamResultViewModel()
                                    {
                                        Name = exam.Key.Name,
                                        MultipleChoiceQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                        EssayQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                        StudentAnswerID = exam.Key.StudentAnswerID,
                                        studentAnswerDetails = new List<StudentAnswerDetailViewModel>()
                                    }).FirstOrDefaultAsync();

            if (examResult == null)
            {
                return new ApiErrorResult<ExamResultViewModel>("Không thể lấy kết quả đề thi");
            }

            var studentAnswerDetails = await (from stad in _context.StudentAnswerDetails
                                              join q in _context.Questions on stad.QuestionID equals q.ID
                                              where stad.StudentAnswerID == examResult.StudentAnswerID
                                              orderby q.IsMultipleChoice
                                              select new StudentAnswerDetailViewModel()
                                              {
                                                  AnswerID = stad.AnswerID,
                                                  QuestionID = q.ID,
                                                  EssayPath = stad.EssayPath,
                                                  StudentAnswerContent = stad.StudentAnswerContent,
                                                  Teacher1Comment = stad.Teacher1Comment,
                                                  Teacher2Comment = stad.Teacher2Comment,
                                                  Mark1 = stad.Mark1,
                                                  Mark2 = stad.Mark2,
                                                  Mark = stad.Mark,
                                                  Question = new QuestionViewModel()
                                                  {
                                                      ID = q.ID,
                                                      Content = q.Content,
                                                      IsMultipleChoice = q.IsMultipleChoice,
                                                      Answers = new List<AnswerCURequest>()
                                                  }
                                              }).ToListAsync();

            foreach (var studentAnswerDetail in studentAnswerDetails)
            {
                // Get all answers of question
                var answers = await (from a in _context.Answers
                                     where a.QuestionID == studentAnswerDetail.QuestionID
                                     select new AnswerCURequest()
                                     {
                                         ID = a.ID,
                                         QuestionID = a.QuestionID,
                                         Content = a.Content,
                                         IsCorrect = a.IsCorrect
                                     }).ToListAsync();

                studentAnswerDetail.Question.Answers = answers.ToList();
            }


            examResult.studentAnswerDetails = studentAnswerDetails.ToList();

            return new ApiSuccessResult<ExamResultViewModel>(examResult);
        }
    }
}

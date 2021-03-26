using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Exams
{
    public class ExamService : IExamService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public ExamService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(ExamCreateRequest request)
        {
            var exam = new Exam()
            {
                Name = request.Name,
                SubjectID = request.SubjectID,
                ExamDetails = new List<ExamDetail>()
            };

            _context.Exams.Add(exam);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<int>("Không thể tạo đề thi");
            }

            return new ApiSuccessResult<int>(exam.ID);
        }

        public async Task<ApiResult<bool>> Update(int id, ExamUpdateRequest request)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return new ApiErrorResult<bool>("Không thể tìm thấy đề thi");

            // If no data change, result will get 0
            if (exam.Name != request.Name)
            {
                exam.Name = request.Name;
                exam.ExamDetails = new List<ExamDetail>();

                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    return new ApiErrorResult<bool>("Không thể chỉnh sửa đề thi");
                }
            }
            else
            {
                exam.ExamDetails = new List<ExamDetail>();
                await _context.SaveChangesAsync();
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return new ApiErrorResult<bool>("Không thể tìm thấy đề thi");
            _context.Exams.Remove(exam);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá đề thi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<ExamViewModel>> GetByID(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return new ApiErrorResult<ExamViewModel>("Đề thi không tồn tại");
            }

            var examViewModel = new ExamViewModel()
            {
                ID = id,
                SubjectID = exam.SubjectID,
                Name = exam.Name
            };

            // Get multiple choice question count
            var multipleChoiceQuestions = from ed in _context.ExamDetails
                                              join q in _context.Questions on ed.QuestionID equals q.ID
                                              where ed.ExamID == id && q.IsMultipleChoice
                                              select q;
            examViewModel.MultipleChoiceQuestionCount = await multipleChoiceQuestions.CountAsync();

            // Get essay question count
            var essayQuestions = from ed in _context.ExamDetails
                                          join q in _context.Questions on ed.QuestionID equals q.ID
                                          where ed.ExamID == id && !q.IsMultipleChoice
                                          select q;
            examViewModel.EssayQuestionCount = await essayQuestions.CountAsync();

            // Get all question of exam
            var questions = await (from ed in _context.ExamDetails
                                   join q in _context.Questions on ed.QuestionID equals q.ID
                                   where ed.ExamID == id
                                   orderby q.IsMultipleChoice
                                   select q).ToListAsync();

            foreach (var quest in questions)
            {
                var questionViewModel = new QuestionViewModel()
                {
                    ID = quest.ID,
                    SubjectID = quest.SubjectID,
                    GroupID = quest.GroupID,
                    Content = quest.Content,
                    IsMultipleChoice = quest.IsMultipleChoice,
                    Answers = new List<AnswerCURequest>()
                };

                // Get all answers of question
                var answers = from a in _context.Answers
                              where a.QuestionID == quest.ID
                              select a;

                foreach (var ans in answers)
                {
                    var answer = new AnswerCURequest()
                    {
                        ID = ans.ID,
                        QuestionID = ans.QuestionID,
                        Content = ans.Content,
                        IsCorrect = ans.IsCorrect
                    };
                    questionViewModel.Answers.Add(answer);
                }

                examViewModel.ExamDetails.Add(new ExamDetailCURequest()
                {
                    ExamID = id,
                    QuestionID = questionViewModel.ID,
                    Question = questionViewModel
                });
            }

            // Get question group ids
            var questionGroups = await (from ed in _context.ExamDetails
                                          join q in _context.Questions on ed.QuestionID equals q.ID
                                          join qg in _context.QuestionGroups on q.GroupID equals qg.ID
                                          where ed.ExamID == id
                                          select qg).Distinct().ToListAsync();

            foreach(var questionGroup in questionGroups)
            {
                examViewModel.QuestionGroups.Add(questionGroup.ID);
            }

            return new ApiSuccessResult<ExamViewModel>(examViewModel);
        }

        public async Task<ApiResult<PagedResult<ExamViewModel>>> GetExamPaging(GetExamPagingRequest request)
        {
            var query = _context.Exams.Where(q => q.Name.Contains(""));
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = _context.Exams.Where(q => q.Name.Contains(request.Keyword));
            }
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ExamViewModel()
                {
                    ID = x.ID,
                    SubjectID = x.SubjectID,
                    Name = x.Name
                }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<ExamViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ExamViewModel>>(pagedResult);
        }
    }
}

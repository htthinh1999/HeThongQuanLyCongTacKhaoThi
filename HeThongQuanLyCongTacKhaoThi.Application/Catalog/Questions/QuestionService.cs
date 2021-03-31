using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public QuestionService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(QuestionCURequest request)
        {
            var question = new Question()
            {
                SubjectID = request.SubjectID,
                GroupID = request.GroupID,
                Content = request.Content,
                IsMultipleChoice = request.IsMultipleChoice,
                Answers = new List<Answer>()
            };

            _context.Questions.Add(question);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<int>("Không thể thêm câu hỏi");
            }

            return new ApiSuccessResult<int>(question.ID);
        }

        public async Task<ApiResult<bool>> Update(int id, QuestionCURequest request)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return new ApiErrorResult<bool>("Không thể tìm thấy câu hỏi");

            // If no data change, result will get 0
            if (question.SubjectID != request.SubjectID || question.GroupID != request.GroupID
                || question.Content != request.Content || question.IsMultipleChoice != request.IsMultipleChoice)
            {
                question.SubjectID = request.SubjectID;
                question.GroupID = request.GroupID;
                question.Content = request.Content;
                question.IsMultipleChoice = request.IsMultipleChoice;
                question.Answers = new List<Answer>();

                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    return new ApiErrorResult<bool>("Không thể sửa câu hỏi");
                }
            }
            else
            {
                question.Answers = new List<Answer>();
                await _context.SaveChangesAsync();
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return new ApiErrorResult<bool>("Không thể tìm thấy câu hỏi");
            _context.Questions.Remove(question);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá câu hỏi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<QuestionViewModel>> GetByID(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return new ApiErrorResult<QuestionViewModel>("Câu hỏi không tồn tại");
            }

            var questionViewModel = new QuestionViewModel()
            {
                ID = id,
                SubjectID = question.SubjectID,
                GroupID = question.GroupID,
                Content = question.Content,
                IsMultipleChoice = question.IsMultipleChoice
            };

            // Get all answer of question if question is multiple choice
            if (questionViewModel.IsMultipleChoice)
            {
                var answers = from q in _context.Questions
                              join a in _context.Answers on q.ID equals a.QuestionID
                              where q.ID == id
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
            }

            return new ApiSuccessResult<QuestionViewModel>(questionViewModel);
        }

        public async Task<ApiResult<PagedResult<QuestionViewModel>>> GetQuestionPaging(GetQuestionPagingRequest request)
        {
            var query = _context.Questions.Where(q => q.Content.Contains(""));
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = _context.Questions.Where(q => q.Content.Contains(request.Keyword));
            }
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsNoTracking()
                .Select(x => new QuestionViewModel()
                {
                    ID = x.ID,
                    SubjectID = x.SubjectID,
                    GroupID = x.GroupID,
                    Content = x.Content,
                    IsMultipleChoice = x.IsMultipleChoice
                }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<QuestionViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<QuestionViewModel>>(pagedResult);
        }

        public ApiResult<bool> ExistQuestionInExam(int id)
        {
            var examDetail = _context.ExamDetails.Where(ed => ed.QuestionID == id).FirstOrDefault();

            if (examDetail != null)
            {
                return new ApiSuccessResult<bool>(true);
            }
            return new ApiSuccessResult<bool>(false);
        }
    }
}
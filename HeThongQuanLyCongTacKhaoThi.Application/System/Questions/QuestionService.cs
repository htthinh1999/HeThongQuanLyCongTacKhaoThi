using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.System.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public QuestionService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(QuestionCreateUpdateRequest request)
        {
            var question = new Question()
            {
                SubjectID = request.SubjectID,
                GroupID = request.GroupID,
                Content = request.Content,
                IsMultipleChoice = request.IsMultipleChoice
            };

            _context.Questions.Add(question);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm câu hỏi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, QuestionCreateUpdateRequest request)
        {
            var _question = await _context.Questions.FindAsync(id);
            if (_question == null) return new ApiErrorResult<bool>("Không thể tìm thấy câu hỏi");

            _question.SubjectID = request.SubjectID;
            _question.GroupID = request.GroupID;
            _question.Content = request.Content;
            _question.IsMultipleChoice = request.IsMultipleChoice;

            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể sửa câu hỏi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var _question = await _context.Questions.FindAsync(id);
            if (_question == null) return new ApiErrorResult<bool>("Không thể tìm thấy câu hỏi");
            _context.Questions.Remove(_question);
            
            var result = await _context.SaveChangesAsync();
            if(result == 0)
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
    }
}

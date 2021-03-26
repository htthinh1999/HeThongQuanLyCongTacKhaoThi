using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public AnswerService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(AnswerCURequest request)
        {
            var answer = new Answer()
            {
                QuestionID = request.QuestionID,
                Content = request.Content,
                IsCorrect = request.IsCorrect
            };

            var question = await _context.Questions.FindAsync(request.QuestionID);
            question.Answers.Add(answer);

            _context.Answers.Add(answer);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm đáp án");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, AnswerCURequest request)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return new ApiErrorResult<bool>("Không thể tìm thấy đáp án");

            answer.QuestionID = request.QuestionID;
            answer.Content = request.Content;
            answer.IsCorrect = request.IsCorrect;

            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể sửa đáp án");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return new ApiErrorResult<bool>("Không thể tìm thấy đáp án");
            _context.Answers.Remove(answer);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá đáp án");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeleteAllAnswersByQuestionID(int id)
        {
            var answers = from a in _context.Answers
                          where a.QuestionID == id
                          select a;
            _context.Answers.RemoveRange(answers);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá đáp án");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<AnswerViewModel>> GetByID(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return new ApiErrorResult<AnswerViewModel>("Đáp án không tồn tại");
            }

            var answerViewModel = new AnswerViewModel()
            {
                ID = id,
                QuestionID = answer.QuestionID,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect
            };
            return new ApiSuccessResult<AnswerViewModel>(answerViewModel);
        }

        public async Task<ApiResult<PagedResult<AnswerViewModel>>> GetAnswerPaging(GetAnswerPagingRequest request)
        {
            var query = _context.Answers.Where(a => a.Content.Contains(""));
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = _context.Answers.Where(a => a.Content.Contains(request.Keyword));
            }
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new AnswerViewModel()
                {
                    ID = x.ID,
                    QuestionID = x.QuestionID,
                    Content = x.Content,
                    IsCorrect = x.IsCorrect
                }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<AnswerViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<AnswerViewModel>>(pagedResult);
        }
    }
}

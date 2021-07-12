using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswerDetails
{
    public class StudentAnswerDetailService : IStudentAnswerDetailService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public StudentAnswerDetailService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(StudentAnswerDetailCreateRequest request)
        {
            var mark = await MarkStudentAnswerDetail(request.StudentAnswerID, request.QuestionID, request.AnswerID);

            var studentAnswerDetail = new StudentAnswerDetail()
            {
                StudentAnswerID = request.StudentAnswerID,
                QuestionID = request.QuestionID,
                AnswerID = request.AnswerID,
                StudentAnswerContent = request.StudentAnswerContent,
                EssayPath = request.EssayPath,
                Mark1 = mark,
                Mark2 = mark,
                Mark = mark
            };

            _context.StudentAnswerDetails.Add(studentAnswerDetail);
            var result = await _context.SaveChangesAsync();

            if(result == 0)
            {
                return new ApiErrorResult<bool>("Không thể tạo chi tiết câu trả lời của học viên");
            }
            return new ApiSuccessResult<bool>();
        }

        private async Task<float?> MarkStudentAnswerDetail(Guid studentAnswerID, int questionID, int? answerID)
        {
            if (answerID == null)
                return null;

            var examID = await _context.StudentAnswers.Where(x=>x.ID == studentAnswerID)
                                                    .Select(x => x.ExamID)
                                                    .FirstOrDefaultAsync();
            var totalEssayQuestionMark = _context.ExamDetails.Where(x => x.ExamID == examID).Sum(x => x.MaxQuestionMark);
            var totalMultipleChoiceQuestionMark = 10 - totalEssayQuestionMark;
            var multipleChoiceQuestionMarkCount = await _context.ExamDetails.Where(x => x.MaxQuestionMark == 0).CountAsync();

            var rightAnswer = await (from a in _context.Answers
                                    where a.QuestionID == questionID && a.ID == answerID && a.IsCorrect == true
                                    select a).FirstOrDefaultAsync();

            if (rightAnswer == null)
                return 0;

            return totalMultipleChoiceQuestionMark / multipleChoiceQuestionMarkCount;
        }
    }
}

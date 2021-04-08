using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswers
{
    public class StudentAnswerService : IStudentAnswerService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public StudentAnswerService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(StudentAnswerCreateRequest request)
        {
            var studentAnswer = new StudentAnswer()
            {
                ID = request.ID,
                UserID = request.AccountID,
                ExamID = request.ExamID
            };

            _context.StudentAnswers.Add(studentAnswer);

            var result = await _context.SaveChangesAsync();
            if(result == 0)
            {
                return new ApiErrorResult<int>("Không thể tạo câu trả lời của học viên");
            }

            return new ApiSuccessResult<int>(studentAnswer.ID);
        }
    }
}

using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
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
            var studentAnswerDetail = new StudentAnswerDetail()
            {
                StudentAnswerID = request.StudentAnswerID,
                QuestionID = request.QuestionID,
                AnswerID = request.AnswerID,
                StudentAnswerContent = request.StudentAnswerContent,
                EssayPath = request.EssayPath,
                Mark = request.Mark
            };

            _context.StudentAnswerDetails.Add(studentAnswerDetail);
            var result = await _context.SaveChangesAsync();

            if(result == 0)
            {
                return new ApiErrorResult<bool>("Không thể tạo chi tiết câu trả lời của học viên");
            }
            return new ApiSuccessResult<bool>();
        }
    }
}

using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.ExamDetails
{
    public class ExamDetailService : IExamDetailService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public ExamDetailService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(ExamDetailCURequest request)
        {
            var examDetail = new ExamDetail()
            {
                ExamID = request.ExamID,
                QuestionID = request.QuestionID
            };

            _context.ExamDetails.Add(examDetail);

            var result = await _context.SaveChangesAsync();

            if(result == 0)
            {
                return new ApiErrorResult<bool>("Không thể tạo chi tiết đề thi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> CreateAllExamDetailsForExam(ExamCreateRequest request)
        {
            // Get & filter multiple choice questions
            var multipleChoiceQuestionsInDB = await (from q in _context.Questions
                                               where request.QuestionGroups.Contains(q.GroupID)
                                                     && q.SubjectID == request.SubjectID
                                                     && q.IsMultipleChoice == true
                                               select q).ToListAsync();

            // Take random from filtered multiple choice questions
            var randomMultipleChoiceQuestions = multipleChoiceQuestionsInDB
                .OrderBy(_ => new Random().Next())
                .Take(request.MultipleChoiceQuestionCount);

            var exam = await _context.Exams.FindAsync(request.ID);

            foreach (var question in randomMultipleChoiceQuestions)
            {
                exam.ExamDetails.Add(new ExamDetail()
                {
                    ExamID = request.ID,
                    QuestionID = question.ID
                });
            }

            // Get & filter essay questions
            var essayQuestionsInDB = await (from q in _context.Questions
                                      where request.QuestionGroups.Contains(q.GroupID)
                                            && q.SubjectID == request.SubjectID
                                            && q.IsMultipleChoice == false
                                      select q).ToListAsync();

            // Take random from filtered essay questions
            var randomEssayQuestions = essayQuestionsInDB
                .OrderBy(_ => new Random().Next())
                .Take(request.EssayQuestionCount);

            foreach (var question in randomEssayQuestions)
            {
                exam.ExamDetails.Add(new ExamDetail()
                {
                    ExamID = request.ID,
                    QuestionID = question.ID
                });
            }

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể tạo đề ngẫu nhiên");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeleteAllQuestionsByExamID(int id)
        {
            var questions = from ed in _context.ExamDetails
                            where ed.ExamID == id
                            select ed;
            foreach(var quest in questions)
            {
                _context.ExamDetails.Remove(quest);
            }

            var result = await _context.SaveChangesAsync();

            if(result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá câu hỏi");
            }

            return new ApiSuccessResult<bool>();
        }


    }
}

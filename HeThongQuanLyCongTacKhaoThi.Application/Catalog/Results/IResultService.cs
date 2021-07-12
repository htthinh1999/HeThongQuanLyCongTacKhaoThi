using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results
{
    public interface IResultService
    {
        Task<ApiResult<bool>> Create(ResultCURequest request);

        Task<ApiResult<PagedResult<ExamResultViewModel>>> GetExamResultPaging(GetExamResultPagingRequest request);

        Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid accountID, int contestID);

        Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid studentAnswerID, Guid teacherID);

        Task<ApiResult<ExamResultViewModel>> GetExamResultToMark(Guid studentAnswerID, Guid teacherID);

        Task<ApiResult<int>> GetTeacherNumber(Guid studentAnswerID, Guid teacherID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="studentAnswerID"></param>
        /// <param name="questionMarked">Key: QuestionID, Value: Mark</param>
        /// <param name="questionCommented">Key: QuestionID, Value: Comment</param>
        /// <returns>Mark exam succeed or not</returns>
        Task<ApiResult<bool>> MarkExam(Guid teacherID, Guid studentAnswerID, Dictionary<int, float> questionMarked, Dictionary<int, string> questionCommented);
        Task<ApiResult<ScoreListViewModel>> GetScoreList(Guid teacherID);
        Task<ApiResult<ScoreListViewModel.StudentResult>> GetScoreListByStudentID(Guid studentID);
    }
}

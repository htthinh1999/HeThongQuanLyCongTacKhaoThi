using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface IResultApiClient
    {
        Task<ApiResult<bool>> Create(ResultCURequest request);

        Task<ApiResult<PagedResult<ExamResultViewModel>>> GetExamResultPaging(GetExamResultPagingRequest request);

        Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid accountID, int contestID);

        Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid studentAnswerID, Guid teacherID);

        Task<ApiResult<ExamResultViewModel>> GetExamResultToMark(Guid studentAnswerID, Guid teacherID);

        Task<ApiResult<int>> GetTeacherNumber(Guid studentAnswerID, Guid teacherID);

        Task<ApiResult<bool>> MarkExam(Guid teacherID, MarkExamRequest request);
    }
}

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

        Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid accountID, int contestID);

        Task<ApiResult<ExamResultViewModel>> GetExamResult(int studentAnswerID, Guid teacherID);
    }
}

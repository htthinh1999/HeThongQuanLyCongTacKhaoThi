using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results
{
    public interface IResultService
    {
        Task<ApiResult<bool>> Create(ResultCURequest request);

        Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid accountID, int contestID);
    }
}

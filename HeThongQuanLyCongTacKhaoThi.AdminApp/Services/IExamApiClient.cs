using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public interface IExamApiClient
    {
        Task<ApiResult<PagedResult<ExamViewModel>>> GetExamPaging(GetExamPagingRequest request);
        Task<ApiResult<ExamViewModel>> GetByID(int id);
        Task<ApiResult<int>> Create(ExamCreateRequest request);
        Task<ApiResult<bool>> Update(int id, ExamUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
    }
}

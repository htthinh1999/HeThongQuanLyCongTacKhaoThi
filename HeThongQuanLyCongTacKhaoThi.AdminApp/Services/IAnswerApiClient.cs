using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public interface IAnswerApiClient
    {
        Task<ApiResult<PagedResult<AnswerViewModel>>> GetAnswerPaging(GetAnswerPagingRequest request);
        Task<ApiResult<AnswerViewModel>> GetByID(int id);
        Task<ApiResult<bool>> Create(AnswerCURequest request);
        Task<ApiResult<bool>> Update(int id, AnswerCURequest request);
        Task<ApiResult<bool>> Delete(int id);
    }
}

using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public interface IQuestionApiClient
    {
        Task<ApiResult<PagedResult<QuestionViewModel>>> GetQuestionPaging(GetQuestionPagingRequest request);
        Task<ApiResult<QuestionViewModel>> GetByID(int id);
        Task<ApiResult<int>> Create(QuestionCURequest request);
        Task<ApiResult<bool>> Update(int id, QuestionCURequest request);
        Task<ApiResult<bool>> Delete(int id);
    }
}

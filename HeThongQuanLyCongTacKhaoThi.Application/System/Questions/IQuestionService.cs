using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.System
{
    public interface IQuestionService
    {
        Task<ApiResult<bool>> Create(QuestionCreateUpdateRequest request);
        Task<ApiResult<bool>> Update(int id, QuestionCreateUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<PagedResult<QuestionViewModel>>> GetQuestionPaging(GetQuestionPagingRequest request);
        Task<ApiResult<QuestionViewModel>> GetByID(int id);
    }
}

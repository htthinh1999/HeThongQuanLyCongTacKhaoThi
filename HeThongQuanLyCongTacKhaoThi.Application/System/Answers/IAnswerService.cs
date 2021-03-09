using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Answers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.System.Answers
{
    public interface IAnswerService
    {
        Task<ApiResult<bool>> Create(AnswerCreateUpdateRequest request);
        Task<ApiResult<bool>> Update(int id, AnswerCreateUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> DeleteAllAnswersByQuestionID(int id);
        Task<ApiResult<PagedResult<AnswerViewModel>>> GetAnswerPaging(GetAnswerPagingRequest request);
        Task<ApiResult<AnswerViewModel>> GetByID(int id);
    }
}

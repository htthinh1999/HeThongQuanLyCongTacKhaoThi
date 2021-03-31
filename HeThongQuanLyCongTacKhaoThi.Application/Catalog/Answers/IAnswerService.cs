using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Answers
{
    public interface IAnswerService
    {
        Task<ApiResult<bool>> Create(AnswerCURequest request);

        Task<ApiResult<bool>> Update(int id, AnswerCURequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> DeleteAllAnswersByQuestionID(int id);

        Task<ApiResult<PagedResult<AnswerViewModel>>> GetAnswerPaging(GetAnswerPagingRequest request);

        Task<ApiResult<AnswerViewModel>> GetByID(int id);
    }
}
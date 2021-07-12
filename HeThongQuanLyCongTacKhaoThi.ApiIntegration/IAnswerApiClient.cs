using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
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
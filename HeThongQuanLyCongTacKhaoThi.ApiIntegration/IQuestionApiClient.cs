using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
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
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Exams
{
    public interface IExamService
    {
        Task<ApiResult<int>> Create(ExamCreateRequest request);

        Task<ApiResult<bool>> Update(int id, ExamUpdateRequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<PagedResult<ExamViewModel>>> GetExamPaging(GetExamPagingRequest request);

        Task<ApiResult<ExamViewModel>> GetByID(int id);
    }
}
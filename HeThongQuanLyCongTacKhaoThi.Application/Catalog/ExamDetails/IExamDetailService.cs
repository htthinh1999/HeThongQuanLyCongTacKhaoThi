using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.ExamDetails
{
    public interface IExamDetailService
    {
        Task<ApiResult<bool>> Create(ExamDetailCURequest request);

        Task<ApiResult<bool>> CreateAllExamDetailsForExam(ExamCreateRequest request);

        Task<ApiResult<bool>> DeleteAllQuestionsByExamID(int id);
    }
}
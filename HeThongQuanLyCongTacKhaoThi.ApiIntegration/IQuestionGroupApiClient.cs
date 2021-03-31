using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface IQuestionGroupApiClient
    {
        Task<ApiResult<List<QuestionGroupViewModel>>> GetAll();

        Task<ApiResult<QuestionGroupViewModel>> GetByID(int id);
    }
}
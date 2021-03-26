using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public interface IQuestionGroupApiClient
    {
        Task<ApiResult<List<QuestionGroupViewModel>>> GetAll();
        Task<ApiResult<QuestionGroupViewModel>> GetByID(int id);
    }
}

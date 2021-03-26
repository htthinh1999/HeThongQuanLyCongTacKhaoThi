using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.QuestionGroups
{
    public interface IQuestionGroupService
    {
        public Task<ApiResult<List<QuestionGroupViewModel>>> GetAll();
        public Task<ApiResult<QuestionGroupViewModel>> GetByID(int id);
    }
}

using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.ScoreType;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.ScoreTypes
{
    public interface IScoreTypeService
    {
        public Task<ApiResult<List<ScoreTypeViewModel>>> GetAll();

        public Task<ApiResult<List<ScoreTypeViewModel>>> GetAllBySubjectID(string subjectID);
    }
}

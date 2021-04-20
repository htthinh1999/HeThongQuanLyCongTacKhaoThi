using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.ScoreType;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface IScoreTypeApiClient
    {
        public Task<ApiResult<List<ScoreTypeViewModel>>> GetAll();

        Task<ApiResult<List<ScoreTypeViewModel>>> GetAllBySubjectID(string subjectID);
    }
}

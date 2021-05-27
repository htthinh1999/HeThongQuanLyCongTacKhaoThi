using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface IStudentAnswerApiClient
    {
        Task<ApiResult<Guid>> Create(StudentAnswerCURequest request);
    }
}

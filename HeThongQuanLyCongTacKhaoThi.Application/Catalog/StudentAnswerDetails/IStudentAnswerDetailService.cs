using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswerDetails
{
    public interface IStudentAnswerDetailService
    {
        Task<ApiResult<bool>> Create(StudentAnswerDetailCreateRequest request);
    }
}

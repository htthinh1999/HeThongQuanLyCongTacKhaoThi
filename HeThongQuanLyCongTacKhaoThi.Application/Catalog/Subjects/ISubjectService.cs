using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Subjects
{
    public interface ISubjectService
    {
        Task<ApiResult<bool>> Create(SubjectCURequest request);
        Task<ApiResult<bool>> Update(int id, SubjectCURequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<PagedResult<SubjectViewModel>>> GetQuestionPaging(GetSubjectPagingRequest request);
        Task<ApiResult<SubjectViewModel>> GetByID(int id);
    }
}

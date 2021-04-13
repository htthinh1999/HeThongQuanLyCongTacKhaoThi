using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface ISubjectApiClient
    {
        Task<ApiResult<List<SubjectViewModel>>> GetAll();

        Task<ApiResult<PagedResult<SubjectViewModel>>> GetSubjectPaging(GetSubjectPagingRequest request);

        Task<ApiResult<SubjectViewModel>> GetByID(string id);

        Task<ApiResult<List<SubjectViewModel>>> GetSubjectsByAccountID(Guid accountID);

        Task<ApiResult<bool>> SubjectAssign(string subjectID, SubjectAssignRequest request);

        Task<ApiResult<bool>> Create(SubjectCURequest request);

        Task<ApiResult<bool>> Update(string id, SubjectCURequest request);

        Task<ApiResult<bool>> Delete(string id);
    }
}

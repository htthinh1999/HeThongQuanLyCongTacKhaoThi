using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface IAccountApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PagedResult<AccountViewModel>>> GetAccountPaging(GetAccountPagingRequest request);

        Task<ApiResult<PagedResult<AccountViewModel>>> GetTeacherPaging(GetAccountPagingRequest request);

        Task<ApiResult<bool>> RegisterAccount(RegisterRequest request);

        Task<ApiResult<bool>> UpdateAccount(Guid id, AccountUpdateRequest request);

        Task<ApiResult<bool>> DeleteAccount(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<AccountViewModel>> GetByID(Guid id);

        Task<ApiResult<AccountViewModel>> GetByUserName(string username);

        Task<ApiResult<List<AccountViewModel>>> GetAllTeachers();
    }
}
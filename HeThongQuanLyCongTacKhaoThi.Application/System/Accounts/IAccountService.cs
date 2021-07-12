using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.System.Accounts
{
    public interface IAccountService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, AccountUpdateRequest request);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<PagedResult<AccountViewModel>>> GetAccountPaging(GetAccountPagingRequest request);

        Task<ApiResult<PagedResult<AccountViewModel>>> GetTeacherPaging(GetAccountPagingRequest request);

        Task<ApiResult<AccountViewModel>> GetByID(Guid id);

        Task<ApiResult<AccountViewModel>> GetByUserName(string username);

        Task<ApiResult<List<AccountViewModel>>> GetAllTeachers();
    }
}
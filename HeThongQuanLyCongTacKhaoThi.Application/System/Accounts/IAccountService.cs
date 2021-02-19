using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.System.Accounts
{
    public interface IAccountService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<bool>> Update(Guid id, AccountUpdateRequest request);
        Task<ApiResult<PagedResult<AccountViewModel>>> GetAccountPaging(GetAccountPagingRequest request);
        Task<ApiResult<AccountViewModel>> GetByID(Guid id);
    }
}

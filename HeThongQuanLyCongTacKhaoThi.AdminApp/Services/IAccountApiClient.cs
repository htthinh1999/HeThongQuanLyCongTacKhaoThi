using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public interface IAccountApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<AccountViewModel>>> GetAccountPaging(GetAccountPagingRequest request);
        Task<ApiResult<bool>> RegisterAccount(RegisterRequest request);
        Task<ApiResult<bool>> UpdateAccount(Guid id, AccountUpdateRequest request);
        Task<ApiResult<AccountViewModel>> GetByID(Guid id);
    }
}

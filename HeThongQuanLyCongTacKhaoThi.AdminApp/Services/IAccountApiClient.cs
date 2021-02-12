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
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<AccountViewModel>> GetAccountPaging(GetAccountPagingRequest request);
    }
}

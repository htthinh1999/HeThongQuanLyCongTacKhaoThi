using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class GetAccountPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

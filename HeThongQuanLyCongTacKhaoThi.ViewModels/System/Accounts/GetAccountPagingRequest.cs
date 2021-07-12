using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class GetAccountPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
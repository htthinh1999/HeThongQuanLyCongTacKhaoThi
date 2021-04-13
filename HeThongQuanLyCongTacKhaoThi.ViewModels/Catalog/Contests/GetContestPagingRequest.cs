using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests
{
    public class GetContestPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

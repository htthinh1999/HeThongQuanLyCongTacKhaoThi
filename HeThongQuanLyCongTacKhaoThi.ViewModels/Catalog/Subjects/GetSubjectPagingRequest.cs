using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects
{
    public class GetSubjectPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class GetExamPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

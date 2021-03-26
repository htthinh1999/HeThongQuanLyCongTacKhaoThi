using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions
{
    public class GetQuestionPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Answers
{
    public class GetAnswerPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

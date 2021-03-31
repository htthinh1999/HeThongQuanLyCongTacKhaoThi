using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class GetExamPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
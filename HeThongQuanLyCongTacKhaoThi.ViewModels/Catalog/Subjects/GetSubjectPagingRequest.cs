using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects
{
    public class GetSubjectPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
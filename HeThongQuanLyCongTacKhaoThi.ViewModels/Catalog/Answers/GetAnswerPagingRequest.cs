using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers
{
    public class GetAnswerPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
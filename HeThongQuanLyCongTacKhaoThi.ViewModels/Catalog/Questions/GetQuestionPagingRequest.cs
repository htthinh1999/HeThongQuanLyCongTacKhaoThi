using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions
{
    public class GetQuestionPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
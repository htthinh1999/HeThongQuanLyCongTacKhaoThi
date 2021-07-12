using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
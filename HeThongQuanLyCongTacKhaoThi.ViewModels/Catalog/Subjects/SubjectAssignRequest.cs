using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects
{
    public class SubjectAssignRequest
    {
        public string SubjectID { get; set; }
        public Guid AccountID { get; set; }
        public string ClassID { get; set; }
    }
}

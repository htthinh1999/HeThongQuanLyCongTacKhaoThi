﻿using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class GetExamResultPagingRequest : PagingRequestBase
    {
        public Guid TeacherID { get; set; }
        public string Keyword { get; set; }
    }
}

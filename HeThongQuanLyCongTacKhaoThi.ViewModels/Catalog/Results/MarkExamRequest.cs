using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results
{
    public class MarkExamRequest
    {
        public Guid StudentAnswerID { get; set; }
        public Dictionary<int, float> QuestionMarked { get; set; }
        public Dictionary<int, string> QuestionCommented { get; set; }
    }
}

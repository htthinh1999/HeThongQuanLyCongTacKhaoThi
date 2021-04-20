using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results
{
    public class ResultCURequest
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string SubjectID { get; set; }
        public int ContestID { get; set; }
        public int ExamID { get; set; }
        public int StudentAnswerID { get; set; }
        public float Mark { get; set; }
        public int Time { get; set; }

    }
}

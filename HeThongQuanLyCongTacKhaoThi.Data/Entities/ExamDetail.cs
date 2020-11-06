using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class ExamDetail
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }

        public Exam Exam { get; set; }
        public Question Question { get; set; }
    }
}

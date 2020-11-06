using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class StudentAnswer
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int ExamID { get; set; }

        public Exam Exam { get; set; }

        public List<StudentAnswerDetail> StudentAnswerDetails { get; set; }
        public List<Result> Results { get; set; }
    }
}

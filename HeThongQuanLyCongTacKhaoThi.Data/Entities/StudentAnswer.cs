using System;
using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class StudentAnswer
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public int ExamID { get; set; }

        public Account Account { get; set; }
        public Exam Exam { get; set; }

        public List<StudentAnswerDetail> StudentAnswerDetails { get; set; }
        public List<Result> Results { get; set; }
    }
}
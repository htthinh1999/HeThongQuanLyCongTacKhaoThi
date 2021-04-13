using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class StudentContest
    {
        public int ContestID { get; set; }
        public Guid AccountID { get; set; }
        public int ExamID { get; set; }

        public Contest Contest { get; set; }
        public Account Account { get; set; }
        public Exam Exam { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Result
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string SubjectID { get; set; }
        public int ScoreID { get; set; }
        public int ExamID { get; set; }
        public int StudentAnswerID { get; set; }
        public float Mark { get; set; }
        public int Time { get; set; }

        public Subject Subject { get; set; }
        public Score Score { get; set; }
        public Exam Exam { get; set; }
        public StudentAnswer StudentAnswer { get; set; }
        public Account Account { get; set; }
    }
}

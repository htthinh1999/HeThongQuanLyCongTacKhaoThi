using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Result
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string SubjectID { get; set; }
        public int ScoreTypeID { get; set; }
        public int ContestID { get; set; }
        public int ExamID { get; set; }
        public int StudentAnswerID { get; set; }
        public float Mark { get; set; }
        public int Time { get; set; }

        public Subject Subject { get; set; }
        public ScoreType ScoreType { get; set; }
        public Contest Contest { get; set; }
        public Exam Exam { get; set; }
        public StudentAnswer StudentAnswer { get; set; }
        public Account Account { get; set; }
    }
}
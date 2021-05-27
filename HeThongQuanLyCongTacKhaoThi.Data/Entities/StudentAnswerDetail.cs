using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class StudentAnswerDetail
    {
        public int ID { get; set; }
        public Guid StudentAnswerID { get; set; }
        public int QuestionID { get; set; }
        public int? AnswerID { get; set; }
        public string EssayPath { get; set; }
        public string StudentAnswerContent { get; set; }
        public string Teacher1Comment { get; set; }
        public string Teacher2Comment { get; set; }
        public float? Mark1 { get; set; }
        public float? Mark2 { get; set; }
        public float? Mark { get; set; }

        public StudentAnswer StudentAnswer { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
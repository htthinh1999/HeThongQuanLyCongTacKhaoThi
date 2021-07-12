namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class ExamDetail
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public float MaxQuestionMark { get; set; }

        public Exam Exam { get; set; }
        public Question Question { get; set; }
    }
}
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class ExamDetailCURequest
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public float MaxQuestionMark { get; set; }
        public QuestionViewModel Question { get; set; }
    }
}
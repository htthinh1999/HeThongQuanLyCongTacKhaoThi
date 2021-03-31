using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions
{
    public class QuestionCURequest
    {
        public int ID { get; set; }

        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }

        [DisplayName("Mã nhóm câu hỏi")]
        public int GroupID { get; set; }

        [DisplayName("Nội dung")]
        public string Content { get; set; }

        [DisplayName("Câu hỏi trắc nghiệm")]
        public bool IsMultipleChoice { get; set; }

        public List<AnswerCURequest> Answers { get; set; } = new List<AnswerCURequest>();
    }
}
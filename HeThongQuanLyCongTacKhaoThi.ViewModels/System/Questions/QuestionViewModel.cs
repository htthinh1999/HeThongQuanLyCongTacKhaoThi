using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions
{
    public class QuestionViewModel
    {
        public int ID { get; set; }
        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }
        [DisplayName("Mã nhóm câu hỏi")]
        public int GroupID { get; set; }
        [DisplayName("Nôi dung")]
        public string Content { get; set; }
        [DisplayName("Câu hỏi trắc nghiệm")]
        public bool IsMultipleChoice { get; set; }
    }
}

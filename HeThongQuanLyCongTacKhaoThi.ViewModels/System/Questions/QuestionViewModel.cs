using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions
{
    public class QuestionViewModel
    {
        public int ID { get; set; }
        public string SubjectID { get; set; }
        public int GroupID { get; set; }
        public string Content { get; set; }
        public bool IsMultipleChoice { get; set; }
    }
}

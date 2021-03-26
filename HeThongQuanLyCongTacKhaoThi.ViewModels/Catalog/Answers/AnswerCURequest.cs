using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers
{
    public class AnswerCURequest
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}

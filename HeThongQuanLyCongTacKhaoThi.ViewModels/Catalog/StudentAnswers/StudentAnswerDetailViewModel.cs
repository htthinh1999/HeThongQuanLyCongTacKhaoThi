using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers
{
    public class StudentAnswerDetailViewModel
    {
        public int ID { get; set; }
        public int StudentAnswerID { get; set; }
        public int QuestionID { get; set; }
        public int? AnswerID { get; set; }
        public string EssayPath { get; set; }
        public string StudentAnswerContent { get; set; }
        public float? Mark1 { get; set; }
        public float? Mark2 { get; set; }
        public float? Mark { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Answer
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        public Question Question { get; set; }

        public List<StudentAnswerDetail> StudentAnswerDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Question
    {
        public int ID { get; set; }
        public string SubjectID { get; set; }
        public string Content { get; set; }
        public bool IsMultipleChoice { get; set; }

        public Subject Subject { get; set; }

        public List<ExamDetail> ExamDetails { get; set; }
        public List<Answer> Answers { get; set; }
        public List<StudentAnswerDetail> StudentAnswerDetails { get; set; }
    }
}

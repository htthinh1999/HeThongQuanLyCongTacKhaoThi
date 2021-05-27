using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers
{
    public class StudentAnswerCURequest
    {
        public Guid ID { get; set; }
        public Guid AccountID { get; set; }
        public int ExamID { get; set; }
        public List<StudentAnswerDetailCreateRequest> studentAnswerDetails { get; set; }
    }
}

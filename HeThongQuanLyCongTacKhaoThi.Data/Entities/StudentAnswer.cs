using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class StudentAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public int ExamID { get; set; }

        public Account Account { get; set; }
        public Exam Exam { get; set; }

        public List<StudentAnswerDetail> StudentAnswerDetails { get; set; }
        public List<Result> Results { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
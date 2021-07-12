using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Notification
    {
        public int ID { get; set; }
        public Guid AccountID { get; set; }
        public Guid StudentAnswerID { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }
        public string SubjectID { get; set; }

        public Account Account { get; set; }
        public StudentAnswer StudentAnswer { get; set; }
        public Subject Subject { get; set; }
    }
}

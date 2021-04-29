using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class SubjectAccount
    {
        public Guid UserID { get; set; }
        public string SubjectID { get; set; }

        public Account Account { get; set; }
        public Subject Subject { get; set; }
    }
}
using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class SubjectTeacher
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string SubjectID { get; set; }
        public string ClassID { get; set; }

        public Account Account { get; set; }
        public Subject Subject { get; set; }
        public Class Class { get; set; }
    }
}
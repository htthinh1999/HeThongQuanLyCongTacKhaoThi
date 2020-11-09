using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Class
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }

        public List<Account> Accounts { get; set; }
        public List<SubjectTeacher> SubjectTeachers { get; set; }
    }
}

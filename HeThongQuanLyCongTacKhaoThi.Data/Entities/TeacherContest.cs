using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class TeacherContest
    {
        public Guid TeacherID { get; set; }
        public int ContestID { get; set; }

        public Account Teacher { get; set; }
        public Contest Contest { get; set; }
    }
}

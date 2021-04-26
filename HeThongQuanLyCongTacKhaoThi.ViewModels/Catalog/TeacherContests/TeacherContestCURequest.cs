using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.TeacherContests
{
    public class TeacherContestCURequest
    {
        public Guid TeacherID { get; set; }
        public int ContestID { get; set; }

        public AccountViewModel Teacher { get; set; }
        public ContestViewModel Contest { get; set; }
    }
}

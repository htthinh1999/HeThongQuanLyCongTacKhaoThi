using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Student_TeacherID { get; set; }
        public string Address { get; set; }
        public string ClassID { get; set; }

    }
}

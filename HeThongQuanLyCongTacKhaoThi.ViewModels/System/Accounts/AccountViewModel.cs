using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Tên tài khoản")]
        public string Username { get; set; }
        [Display(Name = "Tên hiển thị")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Giới tính")]
        public bool Gender { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Mã giảng viên / học viên")]
        public string Student_TeacherID { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Mã lớp")]
        public string ClassID { get; set; }

    }
}

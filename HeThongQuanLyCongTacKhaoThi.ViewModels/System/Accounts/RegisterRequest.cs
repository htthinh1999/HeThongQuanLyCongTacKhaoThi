using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class RegisterRequest
    {
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mã học viên / giảng viên")]
        public string Student_TeacherID { get; set; }
        [Display(Name = "Tên hiển thị")]
        public string Name { get; set; }
        [Display(Name = "Giới tính nam")]
        public bool Gender { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mã lớp")]
        public string ClassID { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}

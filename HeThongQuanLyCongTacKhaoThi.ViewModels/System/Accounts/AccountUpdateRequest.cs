using System;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class AccountUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Mã giảng viên / học viên")]
        public string Student_TeacherID { get; set; }

        [Display(Name = "Tên hiển thị")]
        public string Name { get; set; }

        [Display(Name = "Giới tính")]
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
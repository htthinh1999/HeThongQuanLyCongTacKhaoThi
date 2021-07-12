using FluentValidation;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Tên đăng nhập là bắt buộc");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu là bắt buộc");
            RuleFor(x => x.Student_TeacherID).MaximumLength(10).WithMessage("Độ dài tối đa của mã học viên / giảng viên là 10");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên hiển thị là bắt buộc")
                .MaximumLength(50).WithMessage("Độ dài của tên hiển thị tối đa là 50");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage("Sinh nhật là bắt buộc");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Địa chỉ email là bắt buộc").EmailAddress();
            RuleFor(x => x.ClassID).MaximumLength(15).WithMessage("Độ dài tối đa của mã lớp là 15");
            RuleFor(x => x.Address).MaximumLength(100).WithMessage("Độ dài tối da của địa chỉ là 100");
            RuleFor(x => x).Custom((request, context) =>
              {
                  if (request.Password != request.ConfirmPassword)
                  {
                      context.AddFailure("Mật khẩu xác nhận không trùng khớp");
                  }
              });
        }
    }
}
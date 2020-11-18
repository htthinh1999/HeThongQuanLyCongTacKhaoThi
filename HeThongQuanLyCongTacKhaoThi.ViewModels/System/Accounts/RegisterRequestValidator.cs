using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Student_TeacherID).MaximumLength(10).WithMessage("The max length of teacher/student id is 10");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("The max length of name is 50");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage("Birthday is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress();
            RuleFor(x => x.ClassID).MaximumLength(15).WithMessage("The max length of class id is 15");
            RuleFor(x => x.Address).MaximumLength(100).WithMessage("The max length of address is 100");
            RuleFor(x => x).Custom((request, context) =>
              {
                  if (request.Password != request.ConfirmPassword)
                  {
                      context.AddFailure("Confirm password not math");
                  }
              });
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions
{
    public class QuestionCreateUpdateValidator : AbstractValidator<QuestionCreateUpdateRequest>
    {
        public QuestionCreateUpdateValidator()
        {
            RuleFor(x => x.SubjectID).NotEmpty().WithMessage("Mã môn học là bắt buộc");
            RuleFor(x => x.GroupID).NotEmpty().WithMessage("Mã nhóm câu hỏi là bắt buộc");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Nội dung câu hỏi là bắt buộc");
        }
    }
}

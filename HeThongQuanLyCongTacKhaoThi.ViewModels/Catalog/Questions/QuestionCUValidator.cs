using FluentValidation;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions
{
    public class QuestionCUValidator : AbstractValidator<QuestionCURequest>
    {
        public QuestionCUValidator()
        {
            RuleFor(x => x.SubjectID).NotEmpty().WithMessage("Mã môn học là bắt buộc");
            RuleFor(x => x.GroupID).NotEmpty().WithMessage("Mã nhóm câu hỏi là bắt buộc");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Nội dung câu hỏi là bắt buộc");
        }
    }
}
using Core.Dtos;
using FluentValidation;

namespace SurveyManagementAPI.Validations
{
    public class QuestionValidator : AbstractValidator<QuestionDto>
    {
        public QuestionValidator()
    {
        RuleFor(x => x.Text).NotEmpty().MaximumLength(100);
    }
}
}
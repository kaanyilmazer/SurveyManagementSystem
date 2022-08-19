using Core.Dtos;
using FluentValidation;

namespace SurveyManagementAPI.Validations
{
    public class AnswerValidator : AbstractValidator<AnswerDto>
    {
        public AnswerValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}
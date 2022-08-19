using Core.Dtos;
using FluentValidation;

namespace SurveyManagementAPI.Validations
{
    public class SurveyValidator : AbstractValidator<SurveyDto>
    {
        public SurveyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
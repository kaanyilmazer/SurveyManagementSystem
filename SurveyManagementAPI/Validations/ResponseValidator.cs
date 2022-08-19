using Core.Dtos;
using FluentValidation;

namespace SurveyManagementAPI.Validations
{
    public class ResponseValidator : AbstractValidator<ResponsesDto>
    {
        public ResponseValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(10);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(10);
            RuleFor(x => x.SubmittedDate).NotEmpty();
            RuleFor(x=> x.SurveyId).NotEmpty();
    }
}
}

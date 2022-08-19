using Core.Dtos;
using FluentValidation;

namespace SurveyManagementAPI.Validations
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
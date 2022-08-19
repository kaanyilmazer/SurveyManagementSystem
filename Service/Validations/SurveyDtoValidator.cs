using Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class SurveyDtoValidator:AbstractValidator<SurveyDto>
    {
        public SurveyDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{NAME} is required").NotEmpty().WithMessage("{Name} is required");
            
        }
    }
}

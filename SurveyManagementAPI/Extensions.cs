using FluentValidation.Results;
using SurveyManagementAPI.Responses;

namespace SurveyManagementAPI
{
    public static class Extensions
    {
        public static IEnumerable<object> ToValidationMessage(this List<ValidationFailure> errors)
        {
            return errors.Select(x => new Response
            {
                Message = x.ErrorMessage
               
            });
        }
    }
}
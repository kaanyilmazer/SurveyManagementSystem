using Core.Results;
namespace SurveyManagementAPI.Responses;
public class Response : IResponse
{
    public Response()
    {
    }

    public Response(bool hasError)
    {
        HasError = hasError;
    }
    
    public Response(string message, bool hasError)
    {
        Message = message;
        HasError = hasError;
    }
    
    public Response(Core.Results.IResult result)
    {
        HasError = result.HasError;
        Message = result.Message;
        }
  
    public bool HasError { get; set; }
    public string Message { get; set; }
}
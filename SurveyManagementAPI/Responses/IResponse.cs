namespace SurveyManagementAPI.Responses;

public interface IResponse
{
    bool HasError { get; set; }
    string Message { get; set; }
}
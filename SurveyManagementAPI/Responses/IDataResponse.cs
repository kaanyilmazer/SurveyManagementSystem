
namespace SurveyManagementAPI.Responses;

public interface IDataResponse<T> : IResponse
{
    T Data { get; set; }
}
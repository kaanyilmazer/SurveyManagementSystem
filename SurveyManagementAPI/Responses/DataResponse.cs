
using Core.Results;

namespace SurveyManagementAPI.Responses;

public class DataResponse<T> : Response, IDataResponse<T>
{
    public DataResponse()
    {
    }

    protected DataResponse(bool hasError)
    {
        HasError = hasError;
    }
    
    protected DataResponse(string message, bool hasError)
    {
        Message = message;
        HasError = hasError;
    }
    
    public DataResponse(T data)
    {
        Data = data;
    }

    public DataResponse(T data, bool hasError)
    {
        HasError = hasError;
        Data = data;
    }
    
    public DataResponse(T data, string message)
    {
        Message = message;
        Data = data;
    }
    
    public DataResponse(T data, string message, bool hasError)
    {
        Message = message;
        HasError = hasError;
        Data = data;
    }
    
    public DataResponse(Core.Results.IResult result) : base(result)
    {
    }
    
    public DataResponse(IDataResult<T> result) : base(result)
    {
        Data = result.Data;
    }


    public T Data { get; set; }
}

public class ListResponse<T> : DataResponse<List<T>>, IListResponse<T>
{
    public ListResponse()
    {
    }

    public ListResponse(Core.Results.IResult result) : base(result)
    {
    }

    public ListResponse(IListResult<T> result) : base(result as Core.Results.IResult)
    {
        Data = result.Data;
    }
}
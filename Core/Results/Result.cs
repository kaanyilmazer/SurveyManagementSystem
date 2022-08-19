namespace Core.Results;

public class Result : IResult
{
    public Result()
    {
    }

    public Result(string message)
    {
        Message = message;
    }

    public Result(bool hasError)
    {
        HasError = hasError;
    }

    public Result(string message, bool hasError)
    {
        Message = message;
        HasError = hasError;
    }


    public bool HasError { get; set; }
    public string Message { get; set; }
   
}
namespace Core.Results;

public interface IResult
{
    bool HasError { get; set; }
    string Message { get; set; }
    
}
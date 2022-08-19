namespace Core.Results;

public class ErrorResult : Result
{
    public ErrorResult() : base(true)
    {
    }

    public ErrorResult(string message) : base(message, true)
    {
    }
}
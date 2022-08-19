namespace Core.Results;

public class SuccessResult : Result
{
    public SuccessResult() : base(false)
    {
    }

    public SuccessResult(string message) : base(message, false)
    {
    }
}
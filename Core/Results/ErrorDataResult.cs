namespace Core.Results;

public class ErrorDataResult<T> : DataResult<T>
{

    public ErrorDataResult() : base(true)
    {
    }

    public ErrorDataResult(string message) : base(message, true)
    {
    }
}
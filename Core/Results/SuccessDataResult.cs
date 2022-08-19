namespace Core.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult() : base()
    {
    }
    
    public SuccessDataResult(T data) : base(data, false)
    {
    }

    public SuccessDataResult(T data, string message) : base(data, message, false)
    {
    }
}
namespace Core.Results;

public class DataResult<T> : Result, IDataResult<T>
{
    public DataResult()
    {
    }
    
    public DataResult(T data)
    {
        Data = data;
    }

    public DataResult(bool hasError) : base(hasError)
    {
    }

    public DataResult(string message, bool hasError) : base(message, hasError)
    {
    }

    public DataResult(T data, string message) : base(message)
    {
        Data = data;
    }

    public DataResult(T data, bool hasError) : base(hasError)
    {
        Data = data;
    }

    public DataResult(T data, string message, bool hasError) : base(message, hasError)
    {
        Data = data;
    }

    public T Data { get; set; }
}
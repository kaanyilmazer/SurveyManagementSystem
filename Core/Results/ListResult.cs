namespace Core.Results;

public class ListResult<T> : DataResult<List<T>>, IListResult<T>
{
    public ListResult(List<T> data) : base(data)
    {
    }

    public ListResult(List<T> data, string message) : base(data, message)
    {
    }

    public ListResult(List<T> data, bool hasError) : base(data, hasError)
    {
    }

    public ListResult(List<T> data, string message, bool hasError) : base(data, message, hasError)
    {
    }
}
namespace Core.Results;

public class ErrorListResult<T> : ListResult<T>
{
    public ErrorListResult(List<T> data) : base(data, true)
    {
    }

    public ErrorListResult(List<T> data, string message) : base(data, message, true)
    {
    }
}
namespace Tactsoft.Application.Common;

public class QueryResult<T>
{
    public QueryResult()
    {

    }
    public QueryResult(T result, QueryResultTypeEnum type)
    {
        Result = result;
        Type = type;
    }

    public T Result { get; set; }
    public QueryResultTypeEnum Type { get; set; }
}

public enum QueryResultTypeEnum
{
    Success,
    InvalidInput,
    UnprocessableEntity,
    NotFound,

}
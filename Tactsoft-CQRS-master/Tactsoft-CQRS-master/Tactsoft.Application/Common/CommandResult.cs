namespace Tactsoft.Application.Common;

public class CommandResult<T>
{
    public CommandResult()
    {

    }
    public CommandResult(T result, CommandResultTypeEnum type)
    {
        Result = result;
        Type = type;
    }

    public T Result { get; set; }
    public CommandResultTypeEnum Type { get; set; }
}

public enum CommandResultTypeEnum
{
    Success,
    Created = 201,
    InvalidInput = 400,
    UnprocessableEntity = 500,
    Conflict,
    NotFound = 404,
    UnAuthorized = 401
}
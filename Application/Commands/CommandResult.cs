namespace ExampleCli.Application.Commands;

public sealed class CommandResult
{
    public CommandResult(string message, object? data = null) { Message = message; Data = data; }
    public string Message { get; }
    public object? Data { get; }
}

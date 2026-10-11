using System.Text.Json;
using ExampleCli.Application.Commands;

namespace ExampleCli.Presentation;

public sealed class ConsoleOutput
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };
    public void WriteText(string value) => Console.WriteLine(value);
    public void Write(CommandResult result, bool json)
    {
        if (json) { Console.WriteLine(JsonSerializer.Serialize(new { ok = true, message = result.Message, data = result.Data }, Options)); return; }
        Console.WriteLine(result.Message);
        if (result.Data is not null) Console.WriteLine(JsonSerializer.Serialize(result.Data, Options));
    }
    public void WriteError(string message, bool json)
    {
        if (json) { Console.Error.WriteLine(JsonSerializer.Serialize(new { ok = false, error = message })); return; }
        Console.Error.WriteLine($"Error: {message}");
    }
}

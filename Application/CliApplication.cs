using ExampleCli.Application.Commands;
using ExampleCli.Presentation;
using ExampleCli.Infrastructure;

namespace ExampleCli.Application;

public sealed class CliApplication
{
    public async Task<int> RunAsync(string[] args)
    {
        var output = new ConsoleOutput();
        var options = CliOptions.Parse(args);
        if (options.IsHelpRequested) { output.WriteText(HelpText.Value); return 0; }
        try
        {
            var result = await CommandFactory.Create(options).ExecuteAsync(new WorkspaceDbContextStore());
            output.Write(result, options.Json);
            return 0;
        }
        catch (CliException exception) { output.WriteError(exception.Message, options.Json); return exception.ExitCode; }
    }
}

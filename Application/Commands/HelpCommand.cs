using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public sealed class HelpCommand : CliCommand
{
    public HelpCommand() : base("help") { }
    public override Task<CommandResult> ExecuteAsync(WorkspaceDbContextStore store) => Task.FromResult(new CommandResult(HelpText.Value));
}

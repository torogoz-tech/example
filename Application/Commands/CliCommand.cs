using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public abstract class CliCommand
{
    protected CliCommand(string name) => Name = name;
    public string Name { get; }
    public abstract Task<CommandResult> ExecuteAsync(WorkspaceDbContextStore store);
}

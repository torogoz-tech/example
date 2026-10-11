using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public sealed class DoctorCommand : CliCommand
{
    private readonly CliOptions _options;
    public DoctorCommand(CliOptions options) : base("doctor") => _options = options;
    public override async Task<CommandResult> ExecuteAsync(WorkspaceDbContextStore store)
    {
        var workspace = await store.LoadAsync();
        return new CommandResult("Diagnóstico correcto", new { storage = "ok", provider = "EF Core InMemory", projects = workspace.Projects.Count, tasks = workspace.Tasks.Count });
    }
}

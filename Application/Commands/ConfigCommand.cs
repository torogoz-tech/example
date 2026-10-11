using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public sealed class ConfigCommand : CliCommand
{
    private readonly CliOptions _options;
    public ConfigCommand(CliOptions options) : base("config") => _options = options;
    public override Task<CommandResult> ExecuteAsync(WorkspaceDbContextStore store) => Task.FromResult(new CommandResult("Configuración activa", new { provider = "EF Core InMemory", database = "volatile", json = _options.Json }));
}

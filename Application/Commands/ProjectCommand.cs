using ExampleCli.Domain;
using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public sealed class ProjectCommand : CliCommand
{
    private readonly CliOptions _options;
    public ProjectCommand(CliOptions options) : base("project") => _options = options;
    public override async Task<CommandResult> ExecuteAsync(WorkspaceDbContextStore store)
    {
        var workspace = await store.LoadAsync();
        return (_options.Argument(0) ?? "list") switch
        {
            "list" => new CommandResult("Proyectos encontrados", workspace.Projects),
            "show" => Show(workspace, _options.Argument(1)),
            "create" => await CreateAsync(store, workspace),
            _ => throw new CliException("Uso: project list | project show <id> | project create <name> <description>")
        };
    }
    private static CommandResult Show(Workspace workspace, string? id)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new CliException("Falta el id del proyecto.");
        var project = workspace.Projects.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return project is null ? throw new CliException($"Proyecto no encontrado: {id}") : new CommandResult("Proyecto encontrado", project);
    }

    private async Task<CommandResult> CreateAsync(WorkspaceDbContextStore store, Workspace workspace)
    {
        var name = _options.Argument(1);
        var description = _options.Argument(2);
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            throw new CliException("Uso: project create <name> <description>");

        var project = Project.Create(name, description);
        workspace.Projects.Add(project);
        await store.SaveAsync(workspace);
        return new CommandResult("Proyecto creado", project);
    }
}

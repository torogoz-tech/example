using ExampleCli.Domain;
using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public sealed class TaskCommand : CliCommand
{
    private readonly CliOptions _options;
    public TaskCommand(CliOptions options) : base("task") => _options = options;
    public override async Task<CommandResult> ExecuteAsync(WorkspaceDbContextStore store)
    {
        var workspace = await store.LoadAsync();
        return (_options.Argument(0) ?? "list") switch
        {
            "list" => new CommandResult("Tareas encontradas", workspace.Tasks),
            "add" => await AddAsync(store, workspace),
            "complete" => await CompleteAsync(store, workspace),
            _ => throw new CliException("Uso: task list | task add <project-id> <title> | task complete <id>")
        };
    }
    private async Task<CommandResult> AddAsync(WorkspaceDbContextStore store, Workspace workspace)
    {
        var projectId = _options.Argument(1); var title = _options.Argument(2);
        if (string.IsNullOrWhiteSpace(projectId) || string.IsNullOrWhiteSpace(title)) throw new CliException("Uso: task add <project-id> <title>");
        if (workspace.Projects.All(project => project.Id != projectId)) throw new CliException($"Proyecto no encontrado: {projectId}");
        var task = new WorkspaceTask(IdGenerator.New("task"), projectId, title, false, DateTimeOffset.UtcNow);
        workspace.Tasks.Add(task); await store.SaveAsync(workspace);
        return new CommandResult("Tarea creada", task);
    }
    private async Task<CommandResult> CompleteAsync(WorkspaceDbContextStore store, Workspace workspace)
    {
        var id = _options.Argument(1); var task = workspace.Tasks.FirstOrDefault(item => item.Id == id) ?? throw new CliException($"Tarea no encontrada: {id}");
        task.Complete(); await store.SaveAsync(workspace); return new CommandResult("Tarea completada", task);
    }
}

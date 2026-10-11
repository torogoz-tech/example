namespace ExampleCli.Domain;

public sealed class Workspace
{
    public List<Project> Projects { get; set; } = [];
    public List<WorkspaceTask> Tasks { get; set; } = [];
}

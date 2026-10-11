namespace ExampleCli.Domain;

public sealed class WorkspaceTask
{
    private WorkspaceTask() { }
    public WorkspaceTask(string id, string projectId, string title, bool completed, DateTimeOffset createdAt) { Id = id; ProjectId = projectId; Title = title; Completed = completed; CreatedAt = createdAt; }
    public string Id { get; private set; } = string.Empty;
    public string ProjectId { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public bool Completed { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public void Complete() => Completed = true;
}

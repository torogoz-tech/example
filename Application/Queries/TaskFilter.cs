namespace ExampleCli.Application.Queries;

public sealed class TaskFilter
{
    public string? ProjectId { get; init; }
    public bool? Completed { get; init; }

    public bool Matches(string projectId, bool completed) =>
        (ProjectId is null || ProjectId.Equals(projectId, StringComparison.OrdinalIgnoreCase)) &&
        (Completed is null || Completed == completed);
}

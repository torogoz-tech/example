namespace ExampleCli.Domain;

public sealed class Project
{
    public static Project Create(string name, string description) => new()
    {
        Id = IdGenerator.New("project"),
        Name = name.Trim(),
        Description = description.Trim()
    };

    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}

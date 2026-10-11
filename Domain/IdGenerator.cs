namespace ExampleCli.Domain;

public static class IdGenerator
{
    public static string New(string prefix) => $"{prefix}_{Guid.NewGuid():N}"[..18];
}

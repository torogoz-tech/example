namespace ExampleCli.Application;

public sealed class CliOptions
{
    public string Command { get; private set; } = "help";
    public string[] Arguments { get; private set; } = [];
    public bool Json { get; private set; }
    public bool IsHelpRequested { get; private set; }
    public string DataFile { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".example-cli", "workspace.json");

    public static CliOptions Parse(string[] args)
    {
        var options = new CliOptions(); var arguments = new List<string>();
        foreach (var argument in args)
        {
            switch (argument)
            {
                case "--json": options.Json = true; break;
                case "--help" or "-h": options.IsHelpRequested = true; break;
                case var value when value.StartsWith("--data-file=", StringComparison.Ordinal): options.DataFile = value[12..]; break;
                default: arguments.Add(argument); break;
            }
        }
        if (arguments.Count > 0) { options.Command = arguments[0].ToLowerInvariant(); options.Arguments = arguments.Skip(1).ToArray(); }
        return options;
    }

    public string? Argument(int index) => index < Arguments.Length ? Arguments[index] : null;
}

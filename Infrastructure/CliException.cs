namespace ExampleCli.Infrastructure;

public sealed class CliException : Exception
{
    public CliException(string message, int exitCode = 2) : base(message) => ExitCode = exitCode;
    public int ExitCode { get; }
}

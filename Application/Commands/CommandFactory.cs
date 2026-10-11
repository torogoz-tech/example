using ExampleCli.Infrastructure;

namespace ExampleCli.Application.Commands;

public static class CommandFactory
{
    public static CliCommand Create(CliOptions options) => options.Command switch
    {
        "project" => new ProjectCommand(options), "task" => new TaskCommand(options),
        "config" => new ConfigCommand(options), "doctor" => new DoctorCommand(options),
        "help" => new HelpCommand(), _ => throw new CliException($"Comando desconocido: {options.Command}. Usa --help.")
    };
}

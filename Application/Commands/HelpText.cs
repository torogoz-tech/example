namespace ExampleCli.Application.Commands;

public static class HelpText
{
    public const string Value = """
        example-cli — cliente de terminal local

        Comandos:
          project list                         Lista proyectos
          project show <id>                    Muestra un proyecto
          project create <name> <description>  Crea un proyecto
          task list [--project=<id>]           Filtra tareas por proyecto
          task list [--completed=<true|false>] Filtra por estado
          task add <project-id> <title>        Crea una tarea
          task complete <id>                   Completa una tarea
          config show                          Muestra configuración
          doctor                               Valida el almacenamiento

        Opciones: --json | --data-file=<path> | --help
        """;
}

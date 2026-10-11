# example-cli

Cliente de terminal pequeño pero complejo, construido con .NET 10 y EF Core InMemory.

## Ejemplos

```bash
dotnet run -- project list
dotnet run -- --json task list
dotnet run -- task add demo "Revisar arquitectura"
dotnet run -- doctor
```

La salida JSON usa `{ ok, message, data }` en éxito y `{ ok, error }` en error.

La base de datos se configura en `WorkspaceDbContext`, se inicializa mediante `WorkspaceDbContextStore` y usa `UseInMemoryDatabase`. Es intencionalmente volátil: cada ejecución del CLI parte del seed de demostración. Para persistencia real, se puede sustituir únicamente la configuración del proveedor por SQLite o PostgreSQL.

La estructura mantiene una clase o funcionalidad explícita por archivo, separando `Application`, `Domain`, `Infrastructure` y `Presentation`, sin interfaces innecesarias.

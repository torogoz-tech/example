using ExampleCli.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExampleCli.Infrastructure;

public sealed class WorkspaceDbContextStore
{
    private readonly DbContextOptions<WorkspaceDbContext> _options = new DbContextOptionsBuilder<WorkspaceDbContext>().UseInMemoryDatabase($"example-cli-{Guid.NewGuid():N}").Options;
    public async Task<Workspace> LoadAsync()
    {
        await using var context = CreateContext(); await context.Database.EnsureCreatedAsync();
        if (!await context.Projects.AnyAsync()) await SeedAsync(context);
        return new Workspace { Projects = await context.Projects.AsNoTracking().ToListAsync(), Tasks = await context.Tasks.AsNoTracking().ToListAsync() };
    }
    public async Task SaveAsync(Workspace workspace)
    {
        await using var context = CreateContext(); await context.Database.EnsureCreatedAsync();
        context.Tasks.RemoveRange(context.Tasks); context.Projects.RemoveRange(context.Projects);
        context.Projects.AddRange(workspace.Projects); context.Tasks.AddRange(workspace.Tasks); await context.SaveChangesAsync();
    }
    public async Task<bool> CanConnectAsync()
    {
        await using var context = CreateContext(); return await context.Database.EnsureCreatedAsync();
    }
    private WorkspaceDbContext CreateContext() => new(_options);
    private static async Task SeedAsync(WorkspaceDbContext context)
    {
        context.Projects.Add(new Project { Id = "demo", Name = "Demo CLI", Description = "Proyecto de ejemplo" });
        context.Tasks.Add(new WorkspaceTask("task_demo", "demo", "Explorar comandos", false, DateTimeOffset.UtcNow)); await context.SaveChangesAsync();
    }
}

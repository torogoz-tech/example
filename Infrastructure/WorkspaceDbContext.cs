using ExampleCli.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExampleCli.Infrastructure;

public sealed class WorkspaceDbContext : DbContext
{
    public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options) { }
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<WorkspaceTask> Tasks => Set<WorkspaceTask>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasKey(project => project.Id);
        modelBuilder.Entity<WorkspaceTask>().HasKey(task => task.Id);
        modelBuilder.Entity<WorkspaceTask>().Property(task => task.Title).IsRequired();
        modelBuilder.Entity<WorkspaceTask>().HasOne<Project>().WithMany().HasForeignKey(task => task.ProjectId);
    }
}

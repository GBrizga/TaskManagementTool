using Microsoft.EntityFrameworkCore;
using TaskManagementTool.Api.Entities;

namespace TaskManagementTool.Api.Data;

public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
{
    public DbSet<TodoTask> Tasks => Set<TodoTask>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { Id = 1, Name = "Work" },
            new { Id = 2, Name = "Personal Development" },
            new { Id = 3, Name = "Health & Fitness" },
            new { Id = 4, Name = "Social" },
            new { Id = 5, Name = "Home & Family" },
            new { Id = 6, Name = "Finance" },
            new { Id = 7, Name = "Leisure" },
            new { Id = 8, Name = "Errands" }
            );
    }
}

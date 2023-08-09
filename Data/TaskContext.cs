using Microsoft.EntityFrameworkCore;
using TodoBackend.Models;

namespace TodoBackend.Data;

#pragma warning disable CS1591
public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {

    }

    public DbSet<Models.Task> Tasks => Set<Models.Task>();

    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<User> Users => Set<User>();
}
#pragma warning restore CS1591
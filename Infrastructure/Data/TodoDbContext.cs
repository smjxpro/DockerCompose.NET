using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class TodoDbContext:DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options)
    {
        
    }

    public DbSet<Todo> Todos { get; set; }
}
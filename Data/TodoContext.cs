using Microsoft.EntityFrameworkCore;
using SimpleTodoApi.Models;

namespace SimpleTodoApi.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; } = null!;
}
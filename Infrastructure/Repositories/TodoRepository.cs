using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class TodoRepository : Repository<Todo>, ITodoRepository
{
    public TodoRepository(TodoDbContext context) : base(context)
    {
    }
}
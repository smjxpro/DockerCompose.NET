using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TodoDbContext _context;

    public UnitOfWork(TodoDbContext context)
    {
        _context = context;

        TodoRepository = new TodoRepository(context);
    }

    public ITodoRepository TodoRepository { get; }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
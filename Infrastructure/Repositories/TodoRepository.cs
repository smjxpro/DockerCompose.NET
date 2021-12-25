using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Todo>> GetAllTodo()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetTodoById(Guid id)
    {
        var todo = await _context.Todos.FindAsync(id);
        return todo;
    }

    public async Task<Todo> CreateTodo(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<bool> UpdateTodo(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException e)
        {
            if (!TodoExists(todo.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<bool> DeleteTodo(Guid id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return false;
        }

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return true;
    }


    private bool TodoExists(Guid id)
    {
        return _context.Todos.Any(e => e.Id == id);
    }
}
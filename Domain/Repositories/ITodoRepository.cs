using Domain.Entities;

namespace Domain.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllTodo();
    Task<Todo?> GetTodoById(Guid id);
    Task<Todo> CreateTodo(Todo todo);
    Task<bool> UpdateTodo(Todo todo);
    Task<bool> DeleteTodo(Guid id);
    
}

using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _todoRepository;
   

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    // GET: api/Todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodo()
    {
        var todos = await _todoRepository.GetAllTodo();

        return Ok(todos);
    }

    // GET: api/Todo/6def0e97-d7ab-4d80-bb6e-1ca0b7db0bfa
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Todo>> GetTodoItem(Guid id)
    {
        var todo = await _todoRepository.GetTodoById(id);

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    // PUT: api/Todo/6def0e97-d7ab-4d80-bb6e-1ca0b7db0bfa
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutTodoItem(Guid id, Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        var success = await _todoRepository.UpdateTodo(todo);


        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    // POST: api/Todo
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Todo>> PostTodoItem(Todo todo)
    {
        var newTodo = await _todoRepository.CreateTodo(todo);

        return CreatedAtAction("GetTodoItem", new {id = newTodo.Id}, newTodo);
    }

    // DELETE: api/Todo/6def0e97-d7ab-4d80-bb6e-1ca0b7db0bfa
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodoItem(Guid id)
    {
        var success = await _todoRepository.DeleteTodo(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
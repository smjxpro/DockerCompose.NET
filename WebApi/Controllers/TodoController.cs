using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;


    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodo()
    {
        var todos = await _mediator.Send(new GetAllTodoQuery());

        return Ok(todos);
    }

    // GET: api/Todo/6def0e97-d7ab-4d80-bb6e-1ca0b7db0bfa
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Todo>> GetTodoById(Guid id)
    {
        var todo = await _mediator.Send(new GetTodoByIdQuery {Id = id});

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    // PUT: api/Todo/6def0e97-d7ab-4d80-bb6e-1ca0b7db0bfa
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTodo(Guid id, Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        var success = await _mediator.Send(new UpdateTodoCommand {Id = id, Todo = todo});


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
        var newTodo = await _mediator.Send(new CreateTodoCommand {Todo = todo});

        return CreatedAtAction("GetTodoById", new {id = newTodo.Id}, newTodo);
    }

    // DELETE: api/Todo/6def0e97-d7ab-4d80-bb6e-1ca0b7db0bfa
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodoItem(Guid id)
    {
        var success = await _mediator.Send(new DeleteTodoCommand {Id = id});
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
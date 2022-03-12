using Domain.Entities;
using MediatR;

namespace Application.Commands;

public class CreateTodoCommand:IRequest<Todo>
{
    public Todo Todo { get; set; }
}
using Domain.Entities;
using MediatR;

namespace Application.Commands;

public class UpdateTodoCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public Todo Todo { get; set; }
}
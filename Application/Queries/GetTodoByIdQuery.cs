using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetTodoByIdQuery: IRequest<Todo?>
{
    public Guid Id { get; set; }
}
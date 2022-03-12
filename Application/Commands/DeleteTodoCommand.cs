using MediatR;

namespace Application.Commands;

public class DeleteTodoCommand:IRequest<bool>
{
    public Guid Id { get; set; }
}
using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetAllTodoQuery: IRequest<IEnumerable<Todo>>
{
    
}
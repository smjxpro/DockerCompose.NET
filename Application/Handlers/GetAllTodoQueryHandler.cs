using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class GetAllTodoQueryHandler : IRequestHandler<GetAllTodoQuery, IEnumerable<Todo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTodoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Todo>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<Todo>>(_unitOfWork.TodoRepository.FindAll());
    }
}
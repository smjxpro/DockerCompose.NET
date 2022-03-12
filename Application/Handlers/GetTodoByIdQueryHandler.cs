using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, Todo?>
{
    private readonly IUnitOfWork _unitOfWork;


    public GetTodoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Todo?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_unitOfWork.TodoRepository.FindByCondition(t => t.Id == request.Id).FirstOrDefault());
    }
}
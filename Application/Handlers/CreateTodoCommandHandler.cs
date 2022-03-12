using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Todo>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTodoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.TodoRepository.Create(request.Todo);


        await _unitOfWork.SaveAsync();

        return request.Todo;
    }
}
using Application.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTodoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = _unitOfWork.TodoRepository.FindByCondition(t => t.Id == request.Id).FirstOrDefault();
        if (todo == null) return false;
        _unitOfWork.TodoRepository.Delete(todo);

        await _unitOfWork.SaveAsync();

        return true;
    }
}
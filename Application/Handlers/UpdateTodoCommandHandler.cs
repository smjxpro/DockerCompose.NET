using Application.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTodoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = _unitOfWork.TodoRepository.FindByCondition(t => t.Id == request.Id).FirstOrDefault();
        if (todo == null) return false;
        _unitOfWork.TodoRepository.Update(request.Todo);

        await _unitOfWork.SaveAsync();

        return true;
    }
}
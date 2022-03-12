namespace Domain.Repositories;

public interface IUnitOfWork
{
    public ITodoRepository TodoRepository { get; }

    Task SaveAsync();
}
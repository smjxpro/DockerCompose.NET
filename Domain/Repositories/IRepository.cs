using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
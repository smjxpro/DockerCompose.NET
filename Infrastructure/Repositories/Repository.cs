using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly TodoDbContext Context;

    protected Repository(TodoDbContext context)
    {
        Context = context;
    }

    public IQueryable<T> FindAll()
    {
        return Context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Where(expression).AsNoTracking();
    }

    public void Create(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        Context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
}
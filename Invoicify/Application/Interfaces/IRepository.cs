using System.Linq.Expressions;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IRepository
{
}

public interface IWriteRepository<T> : IDisposable, IRepository where T : BaseEntity, new()
{
    Task<T> GetSingleAsync(int id);
    Task<T> GetFiltered(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void SoftDelete(T entity);
    void SoftDeleteWhere(Expression<Func<T, bool>> predicate);
    Task SaveChangesAsync();
 
    Task<List<T>> GetAllAsync();
    void Update(T entity);
}

public interface IReadRepository<T> : IDisposable, IRepository where T : BaseEntity, new()
{
    Task<List<T>> GetAllAsync();
    int Count();
    Task<T> GetSingleAsync(int id);
    IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
}
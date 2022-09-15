using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base;

public class ReadRepository<T> : IReadRepository<T>
    where T : BaseEntity, new()
{
    private readonly InvoicifyContext _context;

    public ReadRepository(InvoicifyContext context)
    {
        _context = context;
    }

    public virtual Task<List<T>>  GetAllAsync()
    {
        return _context.Set<T>().Where(x => !x.Arch).ToListAsync();
    }

    protected virtual IQueryable<T> GetAllNoTracking()
    {
        return _context.Set<T>().Where(x => !x.Arch).AsNoTracking();
    }

    public virtual int Count()
    {
        return _context.Set<T>().Count(x => !x.Arch);
    }

    public Task<T> GetSingleAsync(int id)
    {
        return _context.Set<T>().Where(x => !x.Arch).FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(x => !x.Arch).Where(predicate);
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

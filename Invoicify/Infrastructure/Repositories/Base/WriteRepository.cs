using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories.Base;

public class WriteRepository<T> : IWriteRepository<T>
    where T : BaseEntity, new()
{
    private readonly DbContext _context;
    private IDbContextTransaction _transaction;

    public WriteRepository(DbContext context)
    {
        _context = context;
    }

    public async Task StartTransaction(CancellationToken token)
    {
        _transaction = await _context.Database.BeginTransactionAsync(token);

    }

    public Task<T> GetSingleAsync(int id)
    {
        return _context.Set<T>().Where(x => !x.Arch).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> GetFiltered(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(x => !x.Arch).Where(predicate).FirstOrDefaultAsync();
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void SoftDelete(T entity)
    {
        var dbEntityEntry = _context.Entry<T>(entity);
        dbEntityEntry.Entity.Arch = true;
    }

    public virtual void SoftDeleteWhere(Expression<Func<T, bool>> predicate)
    {
        IEnumerable<T> entities = _context.Set<T>().Where(x => !x.Arch).Where(predicate);

        foreach (var entity in entities)
        {
            var dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.Entity.Arch = true;
        }
    }

    public virtual Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public virtual void CommitTransaction()
    {
        _transaction.Commit();
    }

    public virtual void RollbackTransaction()
    {
        _transaction.Rollback();
    }

    public virtual Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().Where(x => !x.Arch).ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        _transaction?.Dispose();
    }
}
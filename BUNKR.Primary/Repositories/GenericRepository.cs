using System.Linq.Expressions;
using BUNKR.Primary.Database;
using Microsoft.EntityFrameworkCore;

namespace BUNKR.Primary.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<IReadOnlyCollection<T>> FindAsync(Expression<Func<T, bool>> expression);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BunkrDatabaseContext Context;

    public GenericRepository(BunkrDatabaseContext context)
    {
        Context = context;
    }

    public virtual async Task AddAsync(T entity)
    {
        Context.Set<T>().Add(entity);
        await SaveChangesAsync();
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
        await SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyCollection<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await GetBaseQueryable().Where(expression).AsNoTracking().ToListAsync();
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await GetBaseQueryable().AsNoTracking().ToListAsync();
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllPagedAsync(int page, int countPerPage)
    {
        return await GetBaseQueryable().AsNoTracking().Skip(page * countPerPage).Take(countPerPage).ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        Context.Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    public virtual async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
        await SaveChangesAsync();
    }

    public virtual async Task<int> CountAsync()
    {
        return await GetBaseQueryable().CountAsync();
    }

    protected virtual async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    protected virtual IQueryable<T> GetBaseQueryable()
    {
        return Context
            .Set<T>()
            .AsQueryable();
    }
}
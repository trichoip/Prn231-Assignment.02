using EBookStore.Application.Repositories;
using EBookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> dbSet;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        dbSet = _dbContext.Set<T>();
    }

    public IQueryable<T> Entities => _dbContext.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task<IList<T>> FindAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public Task RemoveAsync(T entity)
    {
        return Task.FromResult(dbSet.Remove(entity));
    }

    public Task UpdateAsync(T entity)
    {
        return Task.FromResult(dbSet.Update(entity));
    }
}

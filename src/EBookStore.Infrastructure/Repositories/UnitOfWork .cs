using EBookStore.Application.Repositories;
using EBookStore.Infrastructure.Data;

namespace EBookStore.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}


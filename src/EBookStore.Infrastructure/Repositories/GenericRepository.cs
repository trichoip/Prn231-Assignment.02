using EBookStore.Application.Repositories;
using EBookStore.Infrastructure.Data;

namespace EBookStore.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}

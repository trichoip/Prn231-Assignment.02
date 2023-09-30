using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Domain.Entities;
using EBookStore.Infrastructure.Data;

namespace EBookStore.Infrastructure.Repositories;
public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PublisherRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

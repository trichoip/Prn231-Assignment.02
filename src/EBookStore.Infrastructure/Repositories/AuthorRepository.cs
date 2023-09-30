using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Domain.Entities;
using EBookStore.Infrastructure.Data;

namespace EBookStore.Infrastructure.Repositories;
public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    private readonly ApplicationDbContext _dbContext;
    public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

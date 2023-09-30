using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Domain.Entities;
using EBookStore.Infrastructure.Data;

namespace EBookStore.Infrastructure.Repositories;
public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly ApplicationDbContext _dbContext;
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

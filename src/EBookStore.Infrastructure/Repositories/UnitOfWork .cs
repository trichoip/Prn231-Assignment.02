using EBookStore.Application.Repositories;
using EBookStore.Infrastructure.Data;
using System.Collections;

namespace EBookStore.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private bool disposed = false;
    private readonly ApplicationDbContext _dbContext;
    private Hashtable _repositories;
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IAuthorRepository AuthorRepository => AuthorRepository ?? new AuthorRepository(_dbContext);

    public IBookRepository BookRepository => BookRepository ?? new BookRepository(_dbContext);

    public IPublisherRepository PublisherRepository => PublisherRepository ?? new PublisherRepository(_dbContext);

    public IUserRepository UserRepository => UserRepository ?? new UserRepository(_dbContext);

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}


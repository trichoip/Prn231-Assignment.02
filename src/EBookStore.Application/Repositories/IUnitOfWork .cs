namespace EBookStore.Application.Repositories;
public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IPublisherRepository PublisherRepository { get; }
    IUserRepository UserRepository { get; }
    Task CommitAsync();
}

using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Domain.Entities;
using EBookStore.Infrastructure.Data;

namespace EBookStore.Infrastructure.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

using EBookStore.Application.DTOs;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.Services;
public interface IUserService
{
    IQueryable<User> Entities { get; }
    Task<User?> FindByIdAsync(int id);
    Task<UserDto> CreateAsync(UserDto entityDto);
    Task UpdateAsync(UserDto entityDto);
    Task RemoveAsync(int id);
}

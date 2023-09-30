using EBookStore.Application.DTOs;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.Services;

public interface IAuthorService
{
    IQueryable<Author> Entities { get; }
    Task<IList<AuthorDto>> FindAllAsync();
    Task<AuthorDto?> FindByIdAsync(int id);
    Task<AuthorDto> CreateAsync(AuthorDto entityDto);
    Task UpdateAsync(AuthorDto entityDto);
    Task RemoveAsync(AuthorDto entityDto);
}

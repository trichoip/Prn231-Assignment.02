using EBookStore.Application.DTOs;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.Services;
public interface IBookService
{
    IQueryable<Book> Entities { get; }
    Task<IList<BookDto>> FindAllAsync();
    Task<BookDto?> FindByIdAsync(int id);
    Task<BookDto> CreateAsync(BookDto entityDto);
    Task UpdateAsync(BookDto entityDto);
    Task RemoveAsync(BookDto entityDto);
}

using EBookStore.Application.DTOs;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.Services;
public interface IPublisherService
{
    IQueryable<Publisher> Entities { get; }
    Task<IList<PublisherDto>> FindAllAsync();
    Task<PublisherDto?> FindByIdAsync(int id);
    Task<PublisherDto> CreateAsync(PublisherDto entityDto);
    Task UpdateAsync(PublisherDto entityDto);
    Task RemoveAsync(PublisherDto entityDto);
}

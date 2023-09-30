using AutoMapper;
using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Application.Services;
using EBookStore.Domain.Entities;

namespace EBookStore.Infrastructure.Services;
public class BookService : IBookService
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public BookService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<Book> Entities => _unitOfWork.BookRepository.Entities;

    public async Task<BookDto> CreateAsync(BookDto entityDto)
    {
        var entity = _mapper.Map<Book>(entityDto);
        await _unitOfWork.BookRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<BookDto>(entity);
    }

    public async Task<IList<BookDto>> FindAllAsync()
    {
        var entities = await _unitOfWork.BookRepository.FindAllAsync();
        return _mapper.Map<IList<BookDto>>(entities);
    }

    public async Task<BookDto?> FindByIdAsync(int id)
    {
        var entity = await _unitOfWork.BookRepository.FindByIdAsync(id);
        return _mapper.Map<BookDto>(entity);
    }

    public async Task RemoveAsync(BookDto entityDto)
    {
        var entity = _mapper.Map<Book>(entityDto);
        await _unitOfWork.BookRepository.RemoveAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(BookDto entityDto)
    {
        var entity = _mapper.Map<Book>(entityDto);
        await _unitOfWork.BookRepository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();
    }
}

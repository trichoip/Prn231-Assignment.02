using AutoMapper;
using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Application.Services;
using EBookStore.Domain.Entities;

namespace EBookStore.Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public AuthorService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<Author> Entities => _unitOfWork.AuthorRepository.Entities;

    public async Task<AuthorDto> CreateAsync(AuthorDto entityDto)
    {
        var entity = _mapper.Map<Author>(entityDto);
        await _unitOfWork.AuthorRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AuthorDto>(entity);
    }

    public async Task<IList<AuthorDto>> FindAllAsync()
    {
        var entities = await _unitOfWork.AuthorRepository.FindAllAsync();
        return _mapper.Map<IList<AuthorDto>>(entities);
    }

    public async Task<AuthorDto?> FindByIdAsync(int id)
    {
        var entity = await _unitOfWork.AuthorRepository.FindByIdAsync(id);
        return _mapper.Map<AuthorDto>(entity);
    }

    public async Task RemoveAsync(AuthorDto entityDto)
    {
        var entity = _mapper.Map<Author>(entityDto);
        await _unitOfWork.AuthorRepository.RemoveAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(AuthorDto entityDto)
    {
        var entity = _mapper.Map<Author>(entityDto);
        await _unitOfWork.AuthorRepository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();
    }
}

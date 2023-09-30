using AutoMapper;
using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Application.Services;
using EBookStore.Domain.Entities;

namespace EPublisherStore.Infrastructure.Services;
public class PublisherService : IPublisherService
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public PublisherService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<Publisher> Entities => _unitOfWork.PublisherRepository.Entities;

    public async Task<PublisherDto> CreateAsync(PublisherDto entityDto)
    {
        var entity = _mapper.Map<Publisher>(entityDto);
        await _unitOfWork.PublisherRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<PublisherDto>(entity);
    }

    public async Task<IList<PublisherDto>> FindAllAsync()
    {
        var entities = await _unitOfWork.PublisherRepository.FindAllAsync();
        return _mapper.Map<IList<PublisherDto>>(entities);
    }

    public async Task<PublisherDto?> FindByIdAsync(int id)
    {
        var entity = await _unitOfWork.PublisherRepository.FindByIdAsync(id);
        return _mapper.Map<PublisherDto>(entity);
    }

    public async Task RemoveAsync(PublisherDto entityDto)
    {
        var entity = _mapper.Map<Publisher>(entityDto);
        await _unitOfWork.PublisherRepository.RemoveAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(PublisherDto entityDto)
    {
        var entity = _mapper.Map<Publisher>(entityDto);
        await _unitOfWork.PublisherRepository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();
    }
}

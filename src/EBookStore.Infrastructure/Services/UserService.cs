using AutoMapper;
using EBookStore.Application.DTOs;
using EBookStore.Application.Repositories;
using EBookStore.Application.Services;
using EBookStore.Domain.Entities;

namespace EBookStore.Infrastructure.Services;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<User> Entities => _unitOfWork.UserRepository.Entities;

    public async Task<UserDto> CreateAsync(UserDto entityDto)
    {
        var entity = _mapper.Map<User>(entityDto);
        await _unitOfWork.UserRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<UserDto>(entity);
    }

    public async Task<IList<UserDto>> FindAllAsync()
    {
        var entities = await _unitOfWork.UserRepository.FindAllAsync();
        return _mapper.Map<IList<UserDto>>(entities);
    }

    public async Task<UserDto?> FindByIdAsync(int id)
    {
        var entity = await _unitOfWork.UserRepository.FindByIdAsync(id);
        return _mapper.Map<UserDto>(entity);
    }

    public async Task RemoveAsync(UserDto entityDto)
    {
        var entity = _mapper.Map<User>(entityDto);
        await _unitOfWork.UserRepository.RemoveAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(UserDto entityDto)
    {
        var entity = _mapper.Map<User>(entityDto);
        await _unitOfWork.UserRepository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();
    }
}

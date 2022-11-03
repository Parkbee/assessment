using System.Collections.Immutable;
using Application.Services.Abstractions;
using Application.Services.Extensions.ModelMappers;
using Data.Repositories.UoW;
using Domain.Models.Pagination;
using Domain.Models.User;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class UserService : IUserService
{
    
    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> CreateUserAsync(UpsertUserRequest upsertUserRequest)
    {
        // Could be a guard clause or something better 
        await ValidateRequest(upsertUserRequest);
        
        var userModel = upsertUserRequest.ToModel();
        await _unitOfWork.UserRepository.CreateUserAsync(userModel);
        await _unitOfWork.CompleteAsync();

        return userModel.ToDto();
    }

    public async Task<UserDto> UpdateUserAsync(UpsertUserRequest upsertUserRequest)
    {
        await ValidateRequest(upsertUserRequest);
        
        var userModel = upsertUserRequest.ToModel();
        await _unitOfWork.UserRepository.CreateUserAsync(userModel);

        return userModel.ToDto();
    }

    public async Task<UserDto> FindUserByLicensePlateAsync(string licensePlate)
    {
        var model = await _unitOfWork.UserRepository.FindByLicensePlateAsync(licensePlate);
        return model is null ? default : model.ToDto();
    }

    public async Task<IPagedResponse<UserDto>> ListUsersPaginatedAsync(int pageNumber = 1, int pageSize = 10)
    {
        var pagedUsers = await _unitOfWork.UserRepository.ListUsersPaginatedAsync(pageNumber, pageSize);
        
        return PagedResponse<UserDto>
            .Create(
                pagedUsers.pageNumber,
                pagedUsers.pageSize,
                pagedUsers.lastPage,
                pagedUsers.items
                    .Select(userModel => userModel?.ToDto())
                    .ToImmutableList());
    }

    private async Task ValidateRequest(UpsertUserRequest upsertUserRequest)
    {
        var user = await _unitOfWork.UserRepository.FindByLicensePlateAsync(upsertUserRequest.LicensePlate);
        if (user is not null)
            throw new Exception($"An user with the plate {user.LicensePlate} already registered");
    }
}
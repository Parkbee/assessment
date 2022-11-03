using Domain.Models.Pagination;
using Domain.Models.User;

namespace Application.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(UpsertUserRequest upsertUserRequest);
    Task<UserDto> UpdateUserAsync(UpsertUserRequest upsertUserRequest);

    Task<UserDto> FindUserByLicensePlateAsync(string licensePlate);
    Task<IPagedResponse<UserDto>> ListUsersPaginatedAsync(int pageNumber = 1, int pageSize = 10);
}
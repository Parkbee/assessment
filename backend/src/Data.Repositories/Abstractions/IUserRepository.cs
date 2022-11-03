using Data.Models.User;

namespace Data.Repositories.Abstractions;

public interface IUserRepository
{
    Task CreateUserAsync(UserModel userModel);
    Task UpdateUserAsync(UserModel userModel);
    Task DeleteUserAsync(Guid userId);

    Task<UserModel?> FindByLicensePlateAsync(string licensePlate);
    Task<UserModel?> FindByIdAsync(Guid userId);
    Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<UserModel?> items)> ListUsersPaginatedAsync(
        int pageNumber, int pageSize);
}
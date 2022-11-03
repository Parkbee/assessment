using Data.Models.User;
using Data.Repositories.Abstractions;
using Data.Repositories.Context;

namespace Data.Repositories;

public class UserRepository : BaseRepository<UserModel, ParkBeeDbContext>, IUserRepository
{
    public UserRepository(ParkBeeDbContext dbContext) : base(dbContext)
    {
    }

    public async Task CreateUserAsync(UserModel userModel)
    {
        await AddAsync(userModel);
    }

    public async Task UpdateUserAsync(UserModel userModel)
    {
        await UpdateAsync(userModel);
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        await DeleteAsync(userId);
    }

    public async Task<UserModel?> FindByLicensePlateAsync(string licensePlate)
    {
        return await FindByPredicateAsync(px => px.LicensePlate.Equals(licensePlate));
    }

    public async Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<UserModel?> items)> ListUsersPaginatedAsync(int pageNumber, int pageSize)
    {
        return await ListPaginatedAsync(px => px.ExternalId != Guid.Empty, pageNumber, pageSize);
    }
}
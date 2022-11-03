using System.Linq.Expressions;
using Data.Models.Garage.Door;
using Data.Repositories.Abstractions;
using Data.Repositories.Context;

namespace Data.Repositories;

public class GarageDoorRepository  : BaseRepository<GarageDoorModel, ParkBeeDbContext>, IGarageDoorRepository
{
    public GarageDoorRepository(ParkBeeDbContext dbContext) : base(dbContext)
    {
        IncludeProperties = new List<Expression<Func<GarageDoorModel, object>>>
        {
            garageDoorModel => garageDoorModel.Garage
        };
    }

    public async Task CreateGarageDoorAsync(GarageDoorModel garageDoorModel)
    {
        await AddAsync(garageDoorModel);
    }

    public async Task UpdateGarageDoorAsync(GarageDoorModel garageDoorModel)
    {
        await UpdateAsync(garageDoorModel);
    }

    public async Task DeleteGarageDoorAsync(Guid garageId, Guid doorId)
    {
        var garageDoorModel = await FindByPredicateAsync(px =>
            px.Garage.ExternalId.Equals(garageId) &&
            px.ExternalId.Equals(doorId));

        if (garageDoorModel is not null)
            await DeleteAsync(garageDoorModel.ExternalId);

    }

    public async Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<GarageDoorModel?> items)> ListGarageDoorPaginatedAsync(int pageNumber, int pageSize)
    {
        return await ListPaginatedAsync(px => px.ExternalId != Guid.Empty, pageNumber, pageSize);
    }
}
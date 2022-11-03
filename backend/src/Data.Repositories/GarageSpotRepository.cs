using System.Linq.Expressions;
using Data.Models.Garage.Spot;
using Data.Repositories.Abstractions;
using Data.Repositories.Context;

namespace Data.Repositories;

public class GarageSpotRepository : BaseRepository<GarageSpotModel, ParkBeeDbContext>, IGarageSpotRepository
{
    public GarageSpotRepository(ParkBeeDbContext dbContext) : base(dbContext)
    {
        IncludeProperties = new List<Expression<Func<GarageSpotModel, object>>>
        {
            garageSpotModel => garageSpotModel.Garage
        };
    }

    public async Task CreateGarageSpotAsync(GarageSpotModel garageSpotModel)
    {
        await AddAsync(garageSpotModel);
    }

    public async Task UpdateGarageSpotAsync(GarageSpotModel garageSpotModel)
    {
        await UpdateAsync(garageSpotModel);
    }

    public async Task DeleteGarageSpotAsync(Guid garageId, Guid spotId)
    {
        var garageSpotModel = await FindByPredicateAsync(px =>
            px.Garage.ExternalId.Equals(garageId) &&
            px.ExternalId.Equals(spotId));

        if (garageSpotModel is not null)
            await DeleteAsync(garageSpotModel.ExternalId);
    }

    public async Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<GarageSpotModel?> items)> ListGarageSpotPaginatedAsync(int pageNumber, int pageSize)
    {
        return await ListPaginatedAsync(px => px.ExternalId != Guid.Empty, pageNumber, pageSize);
    }
}
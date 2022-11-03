using System.Linq.Expressions;
using Data.Models.Garage;
using Data.Repositories.Abstractions;
using Data.Repositories.Context;

namespace Data.Repositories;

public class GarageRepository : BaseRepository<GarageModel, ParkBeeDbContext>, IGarageRepository
{
    public GarageRepository(ParkBeeDbContext dbContext) : base(dbContext)
    {
        IncludeProperties = new List<Expression<Func<GarageModel, object>>>
        {
            garageModel => garageModel.Doors,
            garageModel => garageModel.Spots
        };
    }

    public async Task CreateGarageAsync(GarageModel garageModel)
    {
        await AddAsync(garageModel);
    }

    public async Task UpdateGarageDetailsAsync(GarageModel garageModel)
    {
        await UpdateAsync(garageModel);
    }

    public async Task DeleteGarageAsync(Guid externalId)
    {
        await DeleteAsync(externalId);
    }

    public async Task<GarageModel?> FindByExternalIdAsync(Guid garageExternalId)
    {
        return await FindByPredicateAsync(px => px.ExternalId.Equals(garageExternalId));
    }

    public async Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<GarageModel?> items)> ListGaragePaginatedAsync(int pageNumber, int pageSize)
    {
        return await ListPaginatedAsync(px => px.ExternalId != Guid.Empty, pageNumber, pageSize);
    }
}
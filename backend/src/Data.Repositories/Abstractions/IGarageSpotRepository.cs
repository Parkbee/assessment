using Data.Models.Garage.Spot;

namespace Data.Repositories.Abstractions;

public interface IGarageSpotRepository
{
    Task CreateGarageSpotAsync(GarageSpotModel garageSpotModel);
    Task UpdateGarageSpotAsync(GarageSpotModel garageSpotModel);
    Task DeleteGarageSpotAsync(Guid garageId, Guid spotId);
    
    Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<GarageSpotModel?> items)> ListGarageSpotPaginatedAsync(
        int pageNumber, int pageSize);
}
using Data.Models.Garage;

namespace Data.Repositories.Abstractions;

public interface IGarageRepository
{
    Task CreateGarageAsync(GarageModel garageModel);
    Task UpdateGarageDetailsAsync(GarageModel garageModel);
    Task DeleteGarageAsync(Guid externalId);

    Task<GarageModel?> FindByExternalIdAsync(Guid garageExternalId);
    Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<GarageModel?> items)> ListGaragePaginatedAsync(
        int pageNumber, int pageSize);
}
using Data.Models.Garage.Door;

namespace Data.Repositories.Abstractions;

public interface IGarageDoorRepository
{
    Task CreateGarageDoorAsync(GarageDoorModel garageDoorModel);
    Task UpdateGarageDoorAsync(GarageDoorModel garageDoorModel);
    Task DeleteGarageDoorAsync(Guid garageId, Guid doorId);
    Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<GarageDoorModel?> items)> ListGarageDoorPaginatedAsync(
        int pageNumber, int pageSize);
}
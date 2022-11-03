using Domain.Models.Garage;
using Domain.Models.Pagination;

namespace Application.Services.Abstractions;

public interface IGarageService
{
    Task<GarageDto> CreateGarageAsync(CreateGarageRequest createGarageRequest);
    Task<GarageDto> UpdateGarageDetailsAsync(Guid garageId, UpdateGarageDetailsRequest updateGarageDetailsRequest);
    Task DeleteGarageAsync(Guid garageId);
    Task<IPagedResponse<GarageDto>> ListGaragesPaginatedAsync(int pageNumber = 1, int pageSize = 10);
}
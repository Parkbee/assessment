using System.Collections.Immutable;
using Application.Services.Abstractions;
using Application.Services.Extensions.ModelMappers;
using Data.Repositories.UoW;
using Domain.Models.Garage;
using Domain.Models.Pagination;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class GarageService : IGarageService
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GarageService(ILogger<GarageService> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<GarageDto> CreateGarageAsync(CreateGarageRequest createGarageRequest)
    {
        var garageModel = createGarageRequest.ToModel();
        await _unitOfWork.GarageRepository.CreateGarageAsync(garageModel);
        await _unitOfWork.CompleteAsync();
        
        return garageModel.ToDto();
    }

    public async Task<GarageDto> UpdateGarageDetailsAsync(Guid garageId, UpdateGarageDetailsRequest updateGarageDetailsRequest)
    {
        var garageModel = await _unitOfWork.GarageRepository.FindByExternalIdAsync(garageId);
        if (garageModel is null)
            throw new Exception("Not found");

        garageModel.Name = updateGarageDetailsRequest.Name;
        garageModel.Description = updateGarageDetailsRequest.Description;
        garageModel.Address = updateGarageDetailsRequest.Address;
        
        await _unitOfWork.GarageRepository.UpdateGarageDetailsAsync(garageModel);
        await _unitOfWork.CompleteAsync();
        
        return garageModel.ToDto();
    }

    public async Task DeleteGarageAsync(Guid garageId)
    {
        await _unitOfWork.GarageRepository.DeleteGarageAsync(garageId);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<IPagedResponse<GarageDto>> ListGaragesPaginatedAsync(int pageNumber = 1, int pageSize = 10)
    {
        var pagedGarages = await _unitOfWork.GarageRepository.ListGaragePaginatedAsync(pageNumber, pageSize);
        
        return PagedResponse<GarageDto>
            .Create(
                pagedGarages.pageNumber,
                pagedGarages.pageSize,
                pagedGarages.lastPage,
                pagedGarages.items
                    .Select(garageModel => garageModel?.ToDto())
                    .ToImmutableList());
    }
}
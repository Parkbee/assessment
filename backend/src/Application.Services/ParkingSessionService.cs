using Application.Services.Abstractions;
using Application.Services.Exceptions;
using Application.Services.Extensions.ModelMappers;
using Data.Repositories.UoW;
using Domain.Models.ParkingSession;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class ParkingSessionService : IParkingSessionService
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ParkingSessionService(ILogger<ParkingSessionService> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<ParkingSessionDto> StartParkingSessionAsync(StartParkingSessionRequest startParkingSessionRequest)
    {
        var garageSpots = await _unitOfWork
            .GarageSpotRepository
            .GetAvailableSpotsByGarageIdAsync(startParkingSessionRequest.GarageId);

        if (!garageSpots.Any())
            throw new UnavailableGarageSpotsException();

        var sessionByUser = await _unitOfWork
            .ParkingSessionRepository
            .FindParkingSessionByUserId(startParkingSessionRequest.UserId);

        if (sessionByUser is not null)
            throw new UserAlreadyHaveAnActiveParkingSessionException(startParkingSessionRequest.UserId);

        // Todo: move garage spot behaviours to a specific place.
        var selectedGarageSpot = garageSpots.First();
        selectedGarageSpot.IsAvailable = false;

        var user = await _unitOfWork.UserRepository.FindByIdAsync(startParkingSessionRequest.UserId);
        
        // Todo: Improve logging and error handling!
        try
        {
            var parkingSessionModel = startParkingSessionRequest.ToModel(selectedGarageSpot, user);
            await _unitOfWork.ParkingSessionRepository.CreateParkingSessionAsync(parkingSessionModel);
            await _unitOfWork.GarageSpotRepository.UpdateGarageSpotAsync(selectedGarageSpot);
            
            await _unitOfWork.CompleteAsync();

            return parkingSessionModel.ToDto();
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public async Task<ParkingSessionDto> StopParkingSession(Guid sessionId, DateTime stopTime)
    {
        var parkingSessionModel = await _unitOfWork.ParkingSessionRepository.FindParkingSessionSessionId(sessionId);
        if (parkingSessionModel is null)
            throw new InvalidParkingSessionException();
        
        parkingSessionModel.Stop = DateTime.UtcNow;
        parkingSessionModel.IsActive = false;
        
        //Todo: Move garage spot logic to a specific service!
        var garageSpot = parkingSessionModel.GarageSpot;
        garageSpot.IsAvailable = true;
        
        await _unitOfWork.ParkingSessionRepository.UpdateParkingSessionAsync(parkingSessionModel);
        await _unitOfWork.GarageSpotRepository.UpdateGarageSpotAsync(garageSpot);
        await _unitOfWork.CompleteAsync();

        return parkingSessionModel.ToDto();
    }
    
}
using Domain.Models.ParkingSession;

namespace Application.Services.Abstractions;

public interface IParkingSessionService
{
    Task<ParkingSessionDto> StartParkingSessionAsync(StartParkingSessionRequest startParkingSessionRequest);
    Task<ParkingSessionDto> StopParkingSession(Guid sessionId, DateTime stopTime);
}
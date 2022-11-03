using Data.Models.ParkingSession;

namespace Data.Repositories.Abstractions;

public interface IParkingSessionRepository
{
    Task CreateParkingSessionAsync(ParkingSessionModel parkingSessionModel);
    Task UpdateParkingSessionAsync(ParkingSessionModel parkingSessionModel);

    Task<ParkingSessionModel?> FindParkingSessionByUserId(Guid userId);
    Task<ParkingSessionModel?> FindParkingSessionSessionId(Guid sessionId);
    
    Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<ParkingSessionModel?> items)> ListParkingSessionPaginatedAsync(
        int pageNumber, int pageSize);
}
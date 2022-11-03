using System.Linq.Expressions;
using Data.Models.ParkingSession;
using Data.Repositories.Abstractions;
using Data.Repositories.Context;

namespace Data.Repositories;

public class ParkingSessionRepository : BaseRepository<ParkingSessionModel, ParkBeeDbContext>, IParkingSessionRepository
{
    public ParkingSessionRepository(ParkBeeDbContext dbContext) : base(dbContext)
    {
        //Todo: change it to be a specification
        IncludeProperties = new List<Expression<Func<ParkingSessionModel, object>>>
        {
            px => px.GarageSpot,
            px => px.User
        };
    }

    public async Task CreateParkingSessionAsync(ParkingSessionModel parkingSessionModel)
    {
        await AddAsync(parkingSessionModel);
    }

    public async Task UpdateParkingSessionAsync(ParkingSessionModel parkingSessionModel)
    {
        await UpdateAsync(parkingSessionModel);
    }

    public async Task<ParkingSessionModel?> FindParkingSessionByUserId(Guid userId)
    {
        return await FindByPredicateAsync(px => px.User.ExternalId.Equals(userId));
    }

    public async Task<ParkingSessionModel?> FindParkingSessionSessionId(Guid sessionId)
    {
        return await FindByPredicateAsync(px => px.ExternalId.Equals(sessionId));
    }

    public async Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<ParkingSessionModel?> items)> ListParkingSessionPaginatedAsync(int pageNumber, int pageSize)
    {
        return await ListPaginatedAsync(px => px.ExternalId != Guid.Empty, pageNumber, pageSize);
    }
}
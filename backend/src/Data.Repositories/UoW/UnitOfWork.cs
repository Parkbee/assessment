using Data.Repositories.Abstractions;
using Data.Repositories.Context;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.UoW;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ParkBeeDbContext _parkBeeDbContext;
    private readonly ILogger _logger;
    
    public IGarageRepository GarageRepository { get; }
    public IGarageDoorRepository GarageDoorRepository { get; }
    public IGarageSpotRepository GarageSpotRepository { get; }
    public IUserRepository UserRepository { get; }

    public UnitOfWork(ILogger<ParkBeeDbContext> logger, ParkBeeDbContext parkBeeDbContext)
    {
        _parkBeeDbContext = parkBeeDbContext;
        _logger = logger;

        GarageRepository = new GarageRepository(parkBeeDbContext);
        GarageDoorRepository = new GarageDoorRepository(parkBeeDbContext);
        GarageSpotRepository = new GarageSpotRepository(parkBeeDbContext);
        UserRepository = new UserRepository(parkBeeDbContext);
    }
    
    public async Task CompleteAsync()
    {
        await _parkBeeDbContext.SaveChangesAsync();
        _logger.LogInformation("Storing UnitOfWork context!");
    }

    public void Dispose() => _parkBeeDbContext.Dispose();
}
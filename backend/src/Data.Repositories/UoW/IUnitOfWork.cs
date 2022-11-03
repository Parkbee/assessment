using Data.Repositories.Abstractions;

namespace Data.Repositories.UoW;

public interface IUnitOfWork
{
    IGarageRepository GarageRepository { get; }
    IGarageDoorRepository GarageDoorRepository { get; }
    IGarageSpotRepository GarageSpotRepository { get; }
    IUserRepository UserRepository { get; }
    IParkingSessionRepository ParkingSessionRepository { get; }

    Task CompleteAsync();
}
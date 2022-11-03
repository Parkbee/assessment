using Data.Repositories.Abstractions;

namespace Data.Repositories.UoW;

public interface IUnitOfWork
{
    IGarageRepository GarageRepository { get; }
    IGarageDoorRepository GarageDoorRepository { get; }
    IGarageSpotRepository GarageSpotRepository { get; }

    Task CompleteAsync();
}
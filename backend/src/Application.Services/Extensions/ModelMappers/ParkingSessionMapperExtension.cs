using Data.Models.Garage.Spot;
using Data.Models.ParkingSession;
using Data.Models.User;
using Domain.Models.ParkingSession;

namespace Application.Services.Extensions.ModelMappers;

public static class ParkingSessionMapperExtension
{
    public static ParkingSessionModel ToModel(this StartParkingSessionRequest startParkingSessionRequest,
        GarageSpotModel garageSpotModel, UserModel userModel)
    {
        return new()
        {
            IsActive = true,
            Start = DateTime.UtcNow,
            User = userModel,
            GarageSpot = garageSpotModel
        };
    }

    public static ParkingSessionDto ToDto(this ParkingSessionModel parkingSessionModel)
    {
        return new ParkingSessionDto(
            parkingSessionModel.ExternalId,
            parkingSessionModel.GarageSpot.ExternalId,
            parkingSessionModel.User.ExternalId,
            parkingSessionModel.Start,
            parkingSessionModel.Stop,
            parkingSessionModel.IsActive);
    }
}
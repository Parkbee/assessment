using System.Collections.Immutable;
using Data.Models.Garage;
using Data.Models.Garage.Door;
using Data.Models.Garage.Spot;
using Domain.Models.Garage;
using Domain.Models.Garage.Door;
using Domain.Models.Garage.Spot;

namespace Application.Services.Extensions.ModelMappers;

public static class GarageMapperExtension
{
    public static GarageModel ToModel(this CreateGarageRequest createGarageRequest) =>
        new GarageModel
        {
            Name = createGarageRequest.Name,
            Description = createGarageRequest.Description,
            Address = createGarageRequest.Address,
            Doors = new List<GarageDoorModel>(createGarageRequest.Doors?.Select(px => px.ToModel()) ?? Array.Empty<GarageDoorModel>()),
            Spots = new List<GarageSpotModel>(createGarageRequest.Spots?.Select(px => px.ToModel()) ?? Array.Empty<GarageSpotModel>()),
        };

    public static GarageDoorModel ToModel(this CreateGarageDoorRequest createGarageDoorRequest) =>
        new GarageDoorModel
        {
            Name = createGarageDoorRequest.Name,
            Description = createGarageDoorRequest.Description,
            IpAddress = createGarageDoorRequest.IpAddress,
            IsOpen = false
        };

    public static GarageSpotModel ToModel(this UpsertGarageSpotRequest upsertGarageSpotRequest) =>
        new GarageSpotModel
        {
            Identifier = upsertGarageSpotRequest.Identifier,
            Details = upsertGarageSpotRequest.Details,
            IsAvailable = upsertGarageSpotRequest.IsAvailable
        };


    public static GarageDto ToDto(this GarageModel garageModel) =>
        new GarageDto(
            garageModel.ExternalId,
            garageModel.Name,
            garageModel.Description, 
            garageModel.Doors?.Select(px => px.ToDto()).ToImmutableList() ?? ImmutableList<GarageDoorDto>.Empty, 
            garageModel.Spots?.Select(px => px.ToDto()).ToImmutableList() ?? ImmutableList<GarageSpotDto>.Empty);

    public static GarageDoorDto ToDto(this GarageDoorModel garageDoorModel) =>
        new GarageDoorDto(
            garageDoorModel.ExternalId, 
            garageDoorModel.Name, 
            garageDoorModel.Description, 
            garageDoorModel.IpAddress,
            garageDoorModel.IsOpen);

    public static GarageSpotDto ToDto(this GarageSpotModel garageSpotModel) =>
        new GarageSpotDto(
            garageSpotModel.ExternalId,
            garageSpotModel.Identifier,
            garageSpotModel.Details,
            garageSpotModel.IsAvailable
        );
}
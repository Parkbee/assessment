using System;
using System.Collections.Generic;
using Domain.Models.Garage.Door;
using Domain.Models.Garage.Spot;

namespace Domain.Models.Garage;

public record GarageDto(
    Guid Id, 
    string Name, 
    string Description, 
    IReadOnlyCollection<GarageDoorDto> Doors,
    IReadOnlyCollection<GarageSpotDto> Spots);
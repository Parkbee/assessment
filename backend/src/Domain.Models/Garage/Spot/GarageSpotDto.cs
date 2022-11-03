using System;

namespace Domain.Models.Garage.Spot;

public record GarageSpotDto(
    Guid Id, 
    string Identifier,
    string Details,
    bool IsAvailable);
namespace Domain.Models.Garage.Spot;

public record UpsertGarageSpotRequest(
    string Identifier, 
    string Details, 
    bool IsAvailable);
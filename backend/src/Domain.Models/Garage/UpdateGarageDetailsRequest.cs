namespace Domain.Models.Garage;

public record UpdateGarageDetailsRequest(
    string Name, 
    string Description, 
    string Address);
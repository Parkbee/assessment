namespace Domain.Models.Garage.Door;

public record CreateGarageDoorRequest(
    string Name, 
    string Description, 
    string IpAddress);
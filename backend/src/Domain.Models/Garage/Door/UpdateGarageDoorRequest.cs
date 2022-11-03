namespace Domain.Models.Garage.Door;

public record UpdateGarageDoorRequest(
    string Name, 
    string Description, 
    string IpAddress, 
    bool IsOpen);
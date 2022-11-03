using System;

namespace Domain.Models.Garage.Door;

public record GarageDoorDto(
    Guid Id, 
    string Name, 
    string Description, 
    string IpAddress, 
    bool IsOpen);
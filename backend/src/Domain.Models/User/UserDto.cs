using System;

namespace Domain.Models.User;

public record UserDto(
    Guid Id, 
    string Name, 
    string LicensePlate);
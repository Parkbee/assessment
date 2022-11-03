namespace Domain.Models.User;

public record UpsertUserRequest(
    string UserName, 
    string LicensePlate);
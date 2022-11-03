using System;

namespace Domain.Models.ParkingSession;

public record ParkingSessionDto(
    Guid Id,
    Guid GarageSpotId,
    Guid UserId,
    DateTime StartDateTime,
    DateTime StopDateTime,
    bool IsActive
);
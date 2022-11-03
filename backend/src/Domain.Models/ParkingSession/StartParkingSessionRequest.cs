using System;

namespace Domain.Models.ParkingSession;

public record StartParkingSessionRequest(
    Guid GarageId, 
    Guid UserId, 
    DateTime StartTime);
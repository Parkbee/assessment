using System;

namespace Domain.Models.ParkingSession;


public record StartParkingSessionRequest(string LicensePlate, Guid GarageId);

public record StartParkingSessionResponse(Guid Id, SessionResponseDetails ResponseDetails, DateTime StartTime);
public record StopParkingSessionRequest(Guid ParkingSessionId);

public record StopParkingSessionResponse(TimeSpan SessionTime, string message);
public record SessionResponseDetails(string message, bool status);
namespace Application.Services.Exceptions;

public class InvalidParkingSessionException : Exception
{
    private const string ExceptionMessage = "Invalid Parking Session Id";

    public InvalidParkingSessionException() : base(ExceptionMessage) { }
}
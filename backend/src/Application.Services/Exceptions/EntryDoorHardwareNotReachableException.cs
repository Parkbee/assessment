namespace Application.Services.Exceptions;

public class EntryDoorHardwareNotReachableException : Exception
{
    private const string ExceptionMessage = "Device id: {0} with Ip Address {1} not accessible";

    public EntryDoorHardwareNotReachableException(Guid garageDoorId, string garageDoorIpAddress) : base(
        string.Format(ExceptionMessage, garageDoorId, garageDoorIpAddress))
    {
    }
}
namespace Application.Services.Exceptions;

public class UserAlreadyHaveAnActiveParkingSessionException : Exception
{
    private const string ExceptionMessage = "User: {0} already have an active parking session!";

    public UserAlreadyHaveAnActiveParkingSessionException(Guid userId) : base(string.Format(ExceptionMessage, userId))
    {
    }
}
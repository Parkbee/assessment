namespace Application.Services.Exceptions;

public class UnavailableGarageSpotsException : Exception
{
    private const string ExceptionMessage = "There is no spots available at the specified garage!";

    public UnavailableGarageSpotsException() : base(ExceptionMessage)
    {
    }
}
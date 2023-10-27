namespace S17C241.Exceptions;

public class DomainException : ApplicationException
{
    public DomainException() : base()
    {
    }

    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
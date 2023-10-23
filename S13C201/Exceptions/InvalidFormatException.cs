namespace S13C201.Exceptions;

public class InvalidFormatException : ApplicationException
{
    public InvalidFormatException() : base()
    {
    }

    public InvalidFormatException(string? message) : base(message)
    {
    }

    public InvalidFormatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
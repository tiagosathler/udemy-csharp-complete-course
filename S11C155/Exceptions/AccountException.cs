namespace S11C155.Exceptions;

public class AccountException : ApplicationException
{
    public AccountException()
    {
    }

    public AccountException(string? message) : base(message)
    {
    }

    public AccountException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
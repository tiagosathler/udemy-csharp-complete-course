namespace S11C152.Exceptions;

public class ReservationException : ApplicationException
{
    public ReservationException()
    {
    }

    public ReservationException(string? message) : base(message)
    {
    }

    public ReservationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
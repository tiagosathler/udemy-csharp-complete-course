using S11C152.Exceptions;

namespace S11C152.Entity;

internal sealed class Reservation
{
    public int RoomNumber { get; }
    public DateTime CheckIn { get; private set; }
    public DateTime Checkout { get; private set; }

    public Reservation(int roomNumber, DateTime checkIn, DateTime checkout)
    {
        UpdateDates(checkIn, checkout);
        RoomNumber = roomNumber;
    }

    public int Duration()
    {
        return Checkout.Subtract(CheckIn).Days;
    }

    public void UpdateDates(DateTime checkIn, DateTime checkout)
    {
        if (checkIn > DateTime.Today && checkIn < checkout)
        {
            CheckIn = checkIn;
            Checkout = checkout;
        }
        else
        {
            throw new ReservationException("Check-out date must be later than check-in date and both must be future dates!");
        }
    }

    public override string ToString()
    {
        return $"Reservation: Room {RoomNumber},"
            + $" check-in: {CheckIn.ToString(Program.DTF)},"
            + $" check-out: {Checkout.ToString(Program.DTF)},"
            + $" {Duration()} nights;";
    }
}
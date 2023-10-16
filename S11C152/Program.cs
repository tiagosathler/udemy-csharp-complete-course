using S11C152.Entity;
using S11C152.Exceptions;
using System.Globalization;

namespace S11C152;

internal static class Program
{
    internal static readonly string DTF = "dd/MM/yyyy";

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Reservation reservation = CreateReservation();
        Console.WriteLine(reservation);

        Console.WriteLine("\nEnter data to update the reservation:");

        UpdateReservation(reservation);
        Console.WriteLine(reservation);
    }

    private static int GetRoomNumber()
    {
        int roomNumber;

        do
        {
            Console.Write("Room number: ");
        } while (!int.TryParse(Console.ReadLine(), out roomNumber) || roomNumber <= 0);

        return roomNumber;
    }

    private static Reservation CreateReservation()
    {
        int roomNumber = GetRoomNumber();

        while (true)
        {
            try
            {
                DateTime checkIn = GetDate("Update check-in date");
                DateTime checkout = GetDate("Update check-out date");
                return new Reservation(roomNumber, checkIn, checkout);
            }
            catch (ReservationException e)
            {
                Console.WriteLine("Error when setting reservation dates: " + e.Message);
            }
        }
    }

    private static void UpdateReservation(Reservation reservation)
    {
        bool isValid = false;

        do
        {
            try
            {
                DateTime checkIn = GetDate("Update check-in date");
                DateTime checkout = GetDate("Update check-out date");
                reservation.UpdateDates(checkIn, checkout);
                isValid = true;
            }
            catch (ReservationException e)
            {
                Console.WriteLine("Error updating reservation dates: " + e.Message);
            }
        }
        while (!isValid);
    }

    private static DateTime GetDate(string message)
    {
        DateTime date;

        do
        {
            Console.Write($"{message} ({DTF}): ");
        } while (!DateTime.TryParseExact(Console.ReadLine(), DTF, Thread.CurrentThread.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out date));

        return date;
    }
}
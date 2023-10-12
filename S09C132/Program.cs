using S09C132.Entities;
using S09C132.Services;
using System.Globalization;

namespace S09C132;

internal static class Program
{
    public static readonly string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
    public static readonly string DATE_FORMAT = "dd/MM/yyyy";
    private const int DELAY_TIME = 2000;

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Enter client data:");

        Console.Write("Name: ");
        string clientName = Console.ReadLine()!;

        Console.Write("Email: ");
        string clientEmail = Console.ReadLine()!;

        Console.Write("Birth date: ");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine()!, DATE_FORMAT, Thread.CurrentThread.CurrentCulture);

        Client client = new(clientName, clientEmail, birthDate);

        Order order = new(client);

        OrderService orderService = new(order);

        PrintSummary(order);

        Console.Write("\nHow many items to this order? ");
        int ordersNumber = int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= ordersNumber; i++)
        {
            Console.WriteLine($"\nEnter #{i} item data:");

            Console.Write("Product name: ");
            string productName = Console.ReadLine()!;

            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine()!);

            Console.Write("Quantity: ");
            int productQuantity = int.Parse(Console.ReadLine()!);

            Product product = new(productName, productPrice);

            OrderItem orderItem = new(product, productQuantity);

            orderService.AddItem(orderItem);
            PrintSummary(order);
        }

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine("Trying to change the status...");
            Thread.Sleep(DELAY_TIME);
            orderService.ChangeStatus();
            PrintSummary(order);
        }
    }

    private static void PrintSummary(Order order)
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Order Summary:");
        Console.WriteLine(order);
        Console.WriteLine("--------------------------------------------");
    }
}
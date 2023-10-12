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

        while (order.Status.OrderStatus != Entities.Enums.OrderStatus.DELIVERED)
        {
            AddingItems(order, orderService);
            RemovingItems(order, orderService);

            Console.WriteLine("\nTrying to change the status...");
            Thread.Sleep(DELAY_TIME);
            orderService.ChangeStatus();

            PrintSummary(order);
        }
    }

    private static void AddingItems(Order order, OrderService orderService)
    {
        int ordersNumber = 1;

        Console.Write("\nDo you want to add an item to the cart (y / n) ? ");
        string? chosenOption = Console.ReadLine();

        while (!String.IsNullOrWhiteSpace(chosenOption) && chosenOption.Trim().ToLower().StartsWith('y'))
        {
            Console.WriteLine($"\nEnter #{ordersNumber} item data:");

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

            ordersNumber++;

            Console.Write("\nDo you want to continue adding an item to the cart (y / n) ? ");
            chosenOption = Console.ReadLine();
        }
    }

    private static void RemovingItems(Order order, OrderService orderService)
    {
        Console.Write("\nDo you want to remove an item from the cart (y / n) ? ");
        string? chosenOption = Console.ReadLine();

        while (!String.IsNullOrWhiteSpace(chosenOption) && chosenOption.Trim().ToLower().StartsWith('y'))
        {
            PrintSummary(order);

            Console.Write("Chose item number: ");
            int chosenItem = int.Parse(Console.ReadLine()!);

            OrderItem? orderItem = order.Items.ElementAtOrDefault(chosenItem - 1);

            if (orderItem != null)
            {
                orderService.RemoveItem(orderItem);
                PrintSummary(order);
            }
            else
            {
                Console.WriteLine("Invalid item!");
            }

            Console.Write("\nDo you want to continue removing an item from the cart? (y / n) ? ");
            chosenOption = Console.ReadLine();
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
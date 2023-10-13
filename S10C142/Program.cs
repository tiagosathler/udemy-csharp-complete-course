using S10C142.Entities;
using System.Globalization;

namespace S10C142;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        List<Product> products = new();

        int numberOfProducts = GetNumberOfProducts();

        for (int i = 1; i <= numberOfProducts; i++)
        {
            Console.WriteLine($"\n\x1b[1mProduct #{i} data:\x1b[0m");

            char productStatus = GetProductStatus();
            string name = GetProductName();
            double price = GetProductPrice();

            if (productStatus == 'i')
            {
                double customsFee = GetCustomsFee();
                products.Add(new ImportedProduct(name, price, customsFee));
            }
            else if (productStatus == 'u')
            {
                DateTime manufactureDate = GetManufactureDate();
                products.Add(new UsedProduct(name, price, manufactureDate));
            }
            else
            {
                products.Add(new Product(name, price));
            }
        }

        Console.WriteLine("\n\x1b[1mPRICE TAGS:\x1b[0m");
        foreach (Product product in products)
        {
            Console.WriteLine(product.Tag());
        }
    }

    private static int GetNumberOfProducts()
    {
        int numberOfProducts;

        do
        {
            Console.Write("\nEnter the number of products: ");
        }
        while (!int.TryParse(Console.ReadLine(), out numberOfProducts) || numberOfProducts <= 0);

        return numberOfProducts;
    }

    private static char GetProductStatus()
    {
        char productStatus;
        bool isValid;

        do
        {
            Console.Write("Common, used or imported (c/u/i)? ");
            isValid = (
                char.TryParse(Console.ReadLine(), out productStatus)
                && (productStatus == 'c' || productStatus == 'u' || productStatus == 'i'));
        } while (!isValid);

        return productStatus;
    }

    private static string GetProductName()
    {
        string? name;

        do
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        return name.Trim();
    }

    private static double GetProductPrice()
    {
        double price;
        bool isInvalid;

        do
        {
            Console.Write("Price: ");
            isInvalid = !double.TryParse(Console.ReadLine(), out price) || price <= 0.0;
        } while (isInvalid);

        return price;
    }

    private static double GetCustomsFee()
    {
        double customsFee;
        bool isInvalid;

        do
        {
            Console.Write("Customs fee: ");
            isInvalid = !double.TryParse(Console.ReadLine(), out customsFee) || customsFee <= 0.0;
        } while (isInvalid);

        return customsFee;
    }

    private static DateTime GetManufactureDate()
    {
        DateTime manufactureDate;
        bool isInvalid;

        do
        {
            Console.Write("Manufacture date (DD/MM/YYYY): ");
            isInvalid = !DateTime.TryParseExact(Console.ReadLine(),
                                                "dd/MM/yyyy",
                                                Thread.CurrentThread.CurrentCulture,
                                                DateTimeStyles.AllowWhiteSpaces, out manufactureDate)
                        || manufactureDate > DateTime.Now;
        } while (isInvalid);

        return manufactureDate;
    }
}
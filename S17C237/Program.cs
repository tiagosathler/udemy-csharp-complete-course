using S17C237.Entities;

namespace S17C237;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Category tools = new(1, "Tools", 2);
        Category computers = new(2, "Computers", 1);
        Category electronics = new(3, "Electronics", 1);

        List<Product> products = new();
        products.Add(new Product(1, "Computer", 1100.00, computers));
        products.Add(new Product(2, "Hammer", 90.00, tools));
        products.Add(new Product(3, "TV", 1700.00, electronics));
        products.Add(new Product(4, "Notebook", 1300.00, computers));
        products.Add(new Product(5, "Saw", 80.0, tools));
        products.Add(new Product(6, "Tablet", 700.00, computers));
        products.Add(new Product(7, "Camera", 700.00, electronics));
        products.Add(new Product(8, "Printer", 350.00, electronics));
        products.Add(new Product(9, "MacBook", 1800.00, computers));
        products.Add(new Product(10, "SoundBar", 700.00, electronics));
        products.Add(new Product(11, "Level", 70.00, tools));

        IEnumerable<Product> query1 = products
             .Where(p => p.Category!.Tier == 1 && p.Price < 900.0);

        Print("TIER 1 AND PRICE < 900.00:", query1);

        IEnumerable<string> query2 = products
             .Where(p => p.Category!.Name.Equals("tools", StringComparison.OrdinalIgnoreCase))
             .Select(p => p.Name!);

        Print("NAMES OF PRODUCTS FROM TOOLS CATEGORY:", query2);

        var query3 = products
            .Where(p => p.Name!.Trim().StartsWith("c", StringComparison.OrdinalIgnoreCase))
            .Select(p => new { p.Name, p.Price, CategoryName = p.Category!.Name });

        Print("PRODUCTS THAT BEGIN WITH 'C' AND RESULT IN AN ANONYMOUS OBJECT", query3);

        IEnumerable<Product> query4 = products
            .Where(p => p.Category!.Tier == 1)
            .OrderBy(p => p.Price)
            .ThenBy(p => p.Name);

        Print("PRODUCTS THAT ARE FROM THE TIER 1 CATEGORY AND ORDERED BY PRICE THEN BY NAME IN ASCENDING ORDER", query4);

        IEnumerable<Product> query5 = query4
            .Skip(2)
            .Take(4);

        Print("PRODUCTS THAT ARE FROM THE TIER 1 CATEGORY AND ORDERED BY PRICE THEN BY NAME IN ASCENDING ORDER - SKIP 2 TAKE 4", query5);

        Product? product = products.FirstOrDefault();
        Console.WriteLine($"First or default test 1: {product}");

        product = products.Where(p => p.Price > 3000).FirstOrDefault();
        // product = products.Find(p => p.Price > 3000); // another way without using Linq
        Console.WriteLine($"First or default test 2: {product}");

        Console.WriteLine("---------------------");

        product = products.Where(p => p.Id == 3).SingleOrDefault();
        // product = products.SingleOrDefault(p => p.Id == 3); // another way using Linq
        Console.WriteLine($"Single or default test1: {product}");

        product = products.Where(p => p.Id == 30).SingleOrDefault();
        // product = products.SingleOrDefault(p => p.Id == 30); // another way using Linq
        Console.WriteLine($"Single or default test2: {product}");

        Console.WriteLine("---------------------");

        double maxPrice = products.Max(p => p.Price);
        Console.WriteLine($"Max price: {maxPrice:F2}");

        double minPrice = products.Min(p => p.Price);
        Console.WriteLine($"Min price: {minPrice:F2}");

        Console.WriteLine("---------------------");

        double sumOfPricesInACategory = products
            .Where(p => p.Category!.Id == 1)
            .Sum(p => p.Price);

        Console.WriteLine($"Category 1 sum prices: ${sumOfPricesInACategory:F2}");

        double averageOfPricesInACategory = products
            .Where(p => p.Category!.Id == 1)
            .Average(p => p.Price);

        Console.WriteLine($"Category 1 average prices: ${averageOfPricesInACategory:F2}");

        averageOfPricesInACategory = products
            .Where(p => p.Category!.Id == 30)
            .Select(p => p.Price)
            .DefaultIfEmpty()
            .Average();

        Console.WriteLine($"Category 30 (it doesn't exist) average prices: ${averageOfPricesInACategory:F2}");

        Console.WriteLine("---------------------");

        sumOfPricesInACategory = products
            .Where(p => p.Category!.Id == 1)
            .Select(p => p.Price)
            .Aggregate(0.0, (x, y) => x + y);

        Console.WriteLine($"Category 1 sum prices using Aggregate: ${sumOfPricesInACategory:F2}");

        sumOfPricesInACategory = products
            .Where(p => p.Category!.Id == 30)
            .Select(p => p.Price)
            .Aggregate(0.0, (x, y) => x + y);

        Console.WriteLine($"Category 30 (it doesn't exist) sum prices using Aggregate: ${sumOfPricesInACategory:F2}");

        Console.WriteLine("---------------------");

        foreach (IGrouping<Category, Product> group in products.GroupBy(p => p.Category!))
        {
            Console.WriteLine($"Category: {group.Key.Name}");

            foreach (Product p in group)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
    }

    private static void Print<T>(string message, IEnumerable<T> collection)
    {
        Console.WriteLine(message);

        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("---------------------");
    }
}
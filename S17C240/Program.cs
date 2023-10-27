using S17C237.Entities;

namespace S17C240;

internal static class Program
{
    private static readonly string LINE_SEPARATOR = "---------------------------------------------------------------";

    private static readonly HashSet<Category> categories = new();
    private static readonly HashSet<Product> products = new();

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        PopulateCategories();
        PopulateProducts();

        string queryDescription = "Q1: TIER 1 AND PRICE < 900:";
        var query1 =
                    from p in products
                    where p.Category.Tier == 1 && p.Price < 900
                    select p;
        PrintEnumerableQuery(queryDescription, query1);

        queryDescription = "Q2: NAMES OF PRODUCTS FROM TOOLS";
        var query2 =
                    from p in products
                    where p.Category.Name.Equals("tools", StringComparison.OrdinalIgnoreCase)
                    select p;
        PrintEnumerableQuery(queryDescription, query2);

        queryDescription = "Q3: NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT";
        var query3 =
                    from p in products
                    where p.Name.StartsWith("c", StringComparison.OrdinalIgnoreCase)
                    select new
                    {
                        p.Name,
                        p.Price,
                        CategoryName = p.Category.Name,
                    };
        PrintEnumerableQuery(queryDescription, query3);

        queryDescription = "Q4: TIER 1 ORDER BY PRICE THEN BY NAME";
        var query4 =
                    from p in products
                    where p.Category.Tier == 1
                    orderby p.Name
                    orderby p.Price
                    select p;
        PrintEnumerableQuery(queryDescription, query4);

        queryDescription = "Q5: TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4";
        var query5 = query4
                    .Skip(2)
                    .Take(4);
        PrintEnumerableQuery(queryDescription, query5);

        queryDescription = "Q6: PRODUCTS GROUP BY CATEGORY";
        var query6 =
                    from p in products
                    group p by p.Category;
        PrintEnumerableQuery(queryDescription, query6);
    }

    private static void PopulateCategories()
    {
        Category tools = new(1, "Tools", 2);
        Category computers = new(2, "Computers", 1);
        Category electronics = new(3, "Electronics", 1);
        categories.Add(tools);
        categories.Add(computers);
        categories.Add(electronics);
    }

    private static void PopulateProducts()
    {
        products.Add(new Product(1, "Computer", 1100.00, categories.First(c => c.Id == 2)));
        products.Add(new Product(2, "Hammer", 90.00, categories.First(c => c.Id == 1)));
        products.Add(new Product(3, "TV", 1700.00, categories.First(c => c.Id == 3)));
        products.Add(new Product(4, "Notebook", 1300.00, categories.First(c => c.Id == 2)));
        products.Add(new Product(5, "Saw", 80.0, categories.First(c => c.Id == 1)));
        products.Add(new Product(6, "Tablet", 700.00, categories.First(c => c.Id == 2)));
        products.Add(new Product(7, "Camera", 700.00, categories.First(c => c.Id == 3)));
        products.Add(new Product(8, "Printer", 350.00, categories.First(c => c.Id == 3)));
        products.Add(new Product(9, "MacBook", 1800.00, categories.First(c => c.Id == 2)));
        products.Add(new Product(10, "SoundBar", 700.00, categories.First(c => c.Id == 3)));
        products.Add(new Product(11, "Level", 70.00, categories.First(c => c.Id == 1)));
    }

    private static void PrintEnumerableQuery<T>(string message, IEnumerable<T> collection)
    {
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine(message);

        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
    }

    private static void PrintEnumerableQuery<TKey, TElement>(string message, IEnumerable<IGrouping<TKey, TElement>> collection)
        where TKey : Category
        where TElement : Product
    {
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine(message);

        foreach (var group in collection)
        {
            Console.WriteLine($"Category: {group.Key.Name}");
            foreach (var product in group)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }
    }
}
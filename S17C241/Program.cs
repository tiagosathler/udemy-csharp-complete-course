using S17C241.Entities;
using S17C241.Exceptions;

namespace S17C241;

internal static class Program

{
    private const string DEFAULT_DIRECTORY = "files";
    private const string DEFAULT_FILE_NAME = "input.csv";

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        HashSet<Product> products = new();

        try
        {
            string path = GetDirectoryFullPath();

            List<string> contentOfLines = GetContentOfLinesFromDefaultFileInPath(path);

            products = CreateProductsSetFromContentOfLines(contentOfLines);
        }
        catch (DomainException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }

        ProcessesProductSet(products);
    }

    private static void ProcessesProductSet(HashSet<Product> products)
    {
        if (products.Count < 2)
        {
            Console.WriteLine("\x1b[1mNOT ENOUGH PRODUCTS TO PROCESS. At least 2 are required.\x1b[0m");
        }
        else
        {
            double averagePrice = GetAveragePrices(products);

            IEnumerable<string> productsBelowAveragePrice = GetProductsNameBelowAveragePrice(products, averagePrice);

            PrintResult(averagePrice, productsBelowAveragePrice);
        }
    }

    private static void PrintResult(double averagePrice, IEnumerable<string> productsBelowAveragePrice)
    {
        Console.WriteLine($"\x1b[1mProducts average price: ${averagePrice:F2}\x1b[0m\n");

        Console.WriteLine("Products below average price:");
        foreach (string produtName in productsBelowAveragePrice)
        {
            Console.WriteLine($" - {produtName}");
        }
    }

    private static IEnumerable<string> GetProductsNameBelowAveragePrice(HashSet<Product> products, double averagePrice)
    {
        return
            from p in products
            where p.Price <= averagePrice
            orderby p.Price
            select p.Name;
    }

    private static double GetAveragePrices(HashSet<Product> products)
    {
        return products
            .Select(p => p.Price)
            .DefaultIfEmpty(0.0)
            .Average();
    }

    private static HashSet<Product> CreateProductsSetFromContentOfLines(List<string> contentOfLines)
    {
        HashSet<Product> products = new();

        for (int line = 0; line < contentOfLines.Count; line++)
        {
            string[] fields = contentOfLines[line].Split(',');

            if (fields.Length != 2)
            {
                throw new DomainException($"Error on line {line + 1} of CSV file: format is invalid. It must only have the Name and Price fields");
            }

            string name = fields[0].Trim();

            if (!double.TryParse(fields[1], out double price))
            {
                throw new DomainException($"Error on line {line + 1} of CSV file: format is invalid. The Price field must be in number format 0.00");
            }

            products.Add(new Product(name, price));
        }

        return products;
    }

    private static List<string> GetContentOfLinesFromDefaultFileInPath(string path)
    {
        List<string> contentLines = new();

        try
        {
            using StreamReader sr = File.OpenText(path + DEFAULT_FILE_NAME);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    contentLines.Add(line.Trim());
                }
            }
        }
        catch (Exception e)
        {
            throw new DomainException($"Error when trying to read the file '{DEFAULT_FILE_NAME}': " + e.Message);
        }

        if (contentLines.Count == 0)
        {
            throw new DomainException($"The file {DEFAULT_FILE_NAME} is empty");
        }

        return contentLines;
    }

    private static string GetDirectoryFullPath()
    {
        Console.Write("Enter the full path of the directory containing the 'input.csv' file (press enter for the default path): ");
        string? path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(path))
        {
            DirectoryInfo projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!;
            return projectDirectory.FullName + Path.DirectorySeparatorChar + DEFAULT_DIRECTORY + Path.DirectorySeparatorChar;
        }

        return path.Trim() + Path.DirectorySeparatorChar;
    }
}
using S14C210.Entities;

namespace S14C210;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Printer printer = new("p8021");
        Scanner scanner = new("s3567");
        Combo combo = new("c8421");

        printer.ProcessDoc("my_document.txt");
        printer.Print("my_document.doc");

        Console.WriteLine();

        scanner.ProcessDoc("my passport");
        Console.WriteLine(scanner.Scan());

        Console.WriteLine();

        combo.ProcessDoc("my_dissertation.txt");
        combo.Print("my_dissertation.doc");
        Console.WriteLine(combo.Scan());
    }
}
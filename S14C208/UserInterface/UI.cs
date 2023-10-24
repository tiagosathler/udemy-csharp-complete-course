using S14C208.Entities;
using System.Globalization;

namespace S14C208.UserInterface;

internal static class UI
{
    internal static void PrintHead()
    {
        Console.WriteLine("\x1b[1mEnter contract data\x1b[0m");
    }

    internal static int GetContractNumber()
    {
        int number;

        do
        {
            Console.Write("Number: ");
        }

        while (!int.TryParse(Console.ReadLine(), out number) || number < 1);

        return number;
    }

    internal static DateTime GetContractDate()
    {
        DateTime date;

        do
        {
            Console.Write($"Date ({Program.DTF}): ");
        } while (!DateTime.TryParseExact(Console.ReadLine(), Program.DTF, Thread.CurrentThread.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out date));

        return date;
    }

    internal static double GetContractValue()
    {
        double value;

        do
        {
            Console.Write("Contract value: ");
        } while (!double.TryParse(Console.ReadLine(), out value) || value <= 0);

        return value;
    }

    internal static int GetQuantityOfInstallments()
    {
        int quantity;

        do
        {
            Console.Write("Enter number of installments: ");
        }

        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 1);

        return quantity;
    }

    internal static void PrintContract(Contract contract)
    {
        Console.WriteLine(contract);
    }
}
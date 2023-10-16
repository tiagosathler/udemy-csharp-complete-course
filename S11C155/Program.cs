using S11C155.Entities;
using S11C155.Exceptions;
using System.Globalization;

namespace S11C155;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Account acc = CreateAccount();
        Console.WriteLine($"\n{acc}\n");

        MakeWithdraw(acc);
        Console.WriteLine($"\n{acc}\n");
    }

    private static Account CreateAccount()
    {
        Console.WriteLine("\n\x1b[1mEnter account data:\x1b[0m\n");

        int number = GetAccountNumber();
        string name = GetAccountHolder();
        double balance = GetAccountDoubleValue("Initial balance");
        double withdrawLimit = GetAccountDoubleValue("Withdraw limit");
        return new Account(number, name, balance, withdrawLimit);
    }

    private static void MakeWithdraw(Account acc)
    {
        bool isInvalid = true;

        while (isInvalid)
        {
            try
            {
                double withdraw = GetAccountDoubleValue("Enter amount for withdraw: ");
                acc.Withdraw(withdraw);
                isInvalid = false;
            }
            catch (AccountException e)
            {
                Console.WriteLine($"\n\x1b[1m{e.Message}\x1b[0m");
                Console.WriteLine("Try withdrawing again or enter with zero value");
            }
        }
    }

    private static int GetAccountNumber()
    {
        int number;

        do
        {
            Console.Write("Number: ");
        } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);

        return number;
    }

    private static string GetAccountHolder()
    {
        string? name;

        do
        {
            Console.Write("Holder: ");
            name = Console.ReadLine();
        } while (String.IsNullOrWhiteSpace(name));

        return name.Trim();
    }

    private static double GetAccountDoubleValue(string message)
    {
        double value;

        do
        {
            Console.Write($"{message}: ");
        } while (!double.TryParse(Console.ReadLine(), out value) || value < 0);

        return value;
    }
}
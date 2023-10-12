namespace S09C128;

using S09C128.Entities;
using S09C128.Entities.Enums;
using System;
using System.Globalization;

internal static class Program
{
    private const double MIN_SALARY = 1000.00;
    private const int MAX_CONTRACTS_NUMBER = 10;

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string departament = GetString("Enter department's name");

        Console.WriteLine("\nEnter worker data:");

        string name = GetString("Name");

        WorkerLevel level = GetLevel();

        double baseSalary = GetBaseSalary();

        Worker worker = new(name, level, baseSalary, new Department(departament));

        int numberOfContracts = GetContractsNumber();

        for (int i = 1; i <= numberOfContracts; i++)
        {
            Console.WriteLine($"\nEnter #{i} contract data:");

            DateTime date = GetContractDate();
            double valuePerHour = GetContractHourlyRate();
            int hours = GetContractHours();

            worker.AddContract(new HourContract() { Date = date, Hours = hours, ValuePerHour = valuePerHour });
        }

        DateTime incomeBaseDate = GetIncomeBaseDate();

        PrintResult(worker, incomeBaseDate);
    }

    private static string GetString(string message)
    {
        Console.Write($"{message}: ");
        string? str = Console.ReadLine();

        while (String.IsNullOrWhiteSpace(str))
        {
            Console.Write("Invalid string! Try again: ");
            str = Console.ReadLine();
        }

        return str.Trim();
    }

    private static WorkerLevel GetLevel()
    {
        bool parsed;
        WorkerLevel level;

        do
        {
            string levelString = GetString("Level (Junior / MidLevel / Senior)");
            parsed = Enum.TryParse<WorkerLevel>(levelString.ToUpper(), out level);
            if (!parsed) Console.WriteLine("Invalid level!");
        }
        while (!parsed);

        return level;
    }

    private static double GetBaseSalary()
    {
        double salary;
        bool isInvalid;

        do
        {
            Console.Write("Base Salary: ");
            isInvalid = !double.TryParse(Console.ReadLine()!, out salary) || salary < MIN_SALARY;

            if (isInvalid) Console.WriteLine($"Invalid salary! It must be equal or greater than $ {MIN_SALARY:F2}!");
        }
        while (isInvalid);

        return salary;
    }

    private static int GetContractsNumber()
    {
        Console.Write("\nHow many contracts to this worker? ");

        bool parsed = int.TryParse(Console.ReadLine()!, out int contractsNumber);

        while (contractsNumber <= 0 || contractsNumber > MAX_CONTRACTS_NUMBER || !parsed)
        {
            Console.Write($"Invalid number of contracts. It must be greater than 0 and equal or less than {MAX_CONTRACTS_NUMBER}: ");
            parsed = int.TryParse(Console.ReadLine()!, out contractsNumber);
        }

        return contractsNumber;
    }

    private static DateTime GetContractDate()
    {
        bool parsed;
        DateTime date;

        do
        {
            Console.Write("Date (DD/MM/YYYY): ");
            parsed = DateTime.TryParseExact(Console.ReadLine()!, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date);
            if (!parsed) Console.WriteLine("Invalid date!");
        }
        while (!parsed);

        return date;
    }

    private static double GetContractHourlyRate()
    {
        Console.Write("Value per hour: ");
        bool parsed = double.TryParse(Console.ReadLine()!, out double valuePerHour);

        while (!parsed || valuePerHour <= 0)
        {
            Console.Write("Invalid value per hour. It must be greater than zero: ");
            parsed = double.TryParse(Console.ReadLine()!, out valuePerHour);
        }

        return valuePerHour;
    }

    private static int GetContractHours()
    {
        Console.Write("Duration (hours): ");

        bool parsed = int.TryParse(Console.ReadLine()!, out int hours);

        while (!parsed || hours <= 0)
        {
            Console.Write("Invalid hours. It must be greater than zero: ");
            parsed = int.TryParse(Console.ReadLine()!, out hours);
        }

        return hours;
    }

    private static DateTime GetIncomeBaseDate()
    {
        Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");

        DateTime date;
        bool parsed;

        do
        {
            parsed = DateTime.TryParseExact(Console.ReadLine()!, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date);
            if (!parsed) Console.Write("Invalid date! Try again (MM/YYYY): ");
        } while (!parsed);

        return date;
    }

    private static void PrintResult(Worker worker, DateTime baseDate)
    {
        double incomeFromBaseDate = worker.Income(baseDate.Year, baseDate.Month);
        Console.WriteLine($"\nName: {worker.Name}");
        Console.WriteLine($"Department: {worker.Department!.Name}");
        Console.WriteLine($"Income for {baseDate.Month:D2}/{baseDate.Year}: $ {incomeFromBaseDate:F2}");
    }
}
using S10C146.Entities;

namespace S10C146;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        List<Taxpayer> taxpayers = new();

        int iteration = 1;

        do
        {
            Console.WriteLine($"\n\x1b[1mTaxpayer #{iteration} data:\x1b[0m");

            char taxpayerType = GetTaxpayerType();
            string name = GetName();
            double annualIncome = GetDouble("Annual income");

            if (taxpayerType == 'i')
            {
                double healthExpenditures = GetDouble("Health expenditures");
                taxpayers.Add(new IndividualTaxpayer(name, annualIncome, healthExpenditures));
            }
            else if (taxpayerType == 'c')
            {
                int numberOfEmployees = GetNumberOfEmployees();
                taxpayers.Add(new LegalEntityTaxpayer(name, annualIncome, numberOfEmployees));
            }

            iteration++;
        } while (Adding());

        Console.WriteLine($"\n\x1b[1mTAXES PAID ({taxpayers.Count})\x1b[0m:");
        foreach (Taxpayer taxpayer in taxpayers)
        {
            Console.WriteLine($" - {taxpayer}");
        }

        Console.WriteLine($"\n\x1b[1mTOTAL TAXES: $ {taxpayers.Sum(t => t.GetTaxesPaid()):F2}\x1b[0m:");
    }

    private static char GetTaxpayerType()
    {
        char chosen;

        do
        {
            Console.Write("Individual or company (i / c)? ");
        } while (
            !(char.TryParse(Console.ReadLine(), out chosen)
            && (chosen == 'i' || chosen == 'c')));

        return chosen;
    }

    private static string GetName()
    {
        string? name;

        do
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
        } while (String.IsNullOrWhiteSpace(name));

        return name.Trim();
    }

    private static double GetDouble(string message)
    {
        double value;

        do
        {
            Console.Write($"{message}: ");
        } while (!double.TryParse(Console.ReadLine(), out value) || value < 0.0);

        return value;
    }

    private static int GetNumberOfEmployees()
    {
        int numberOfEmployees;

        do
        {
            Console.Write("Number of employees: ");
        } while (!int.TryParse(Console.ReadLine(), out numberOfEmployees) || numberOfEmployees < 0);

        return numberOfEmployees;
    }

    private static bool Adding()
    {
        Console.WriteLine();
        char chosen;

        do
        {
            Console.Write("Do you want to add more taxpayers (y / n)? ");
        } while (
            !(char.TryParse(Console.ReadLine(), out chosen)
            && (chosen == 'y' || chosen == 'n')));

        return chosen == 'y';
    }
}
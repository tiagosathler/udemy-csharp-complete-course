using S10C140.Entities;

namespace S10C140;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        List<Employee> employees = new();

        Console.Write("Enter the number of employees: ");
        int.TryParse(Console.ReadLine(), out int numberOfEmployees);

        for (int i = 1; i <= numberOfEmployees; i++)
        {
            Console.WriteLine($"\n\x1b[1mEmployee #{i} data:\x1b[0m");

            Console.Write("Outsourced (y/n)? ");
            string? choosenOutsourced = Console.ReadLine();
            choosenOutsourced = String.IsNullOrWhiteSpace(choosenOutsourced) ? "n" : choosenOutsourced.Trim().ToLower();

            Console.Write("Name: ");
            string? name = Console.ReadLine();
            name = String.IsNullOrWhiteSpace(name) ? "EMPTY NAME" : name.Trim();

            Console.Write("Hours: ");
            int.TryParse(Console.ReadLine(), out int hours);

            Console.Write("Value per hour: ");
            double.TryParse(Console.ReadLine(), out double valuePerHour);

            if (choosenOutsourced.StartsWith('y'))
            {
                Console.Write("Additional charge: ");
                double.TryParse(Console.ReadLine(), out double additionalCharge);

                employees.Add(new OutsourceEmployee(name, hours, valuePerHour, additionalCharge));
            }
            else
            {
                employees.Add(new Employee(name, hours, valuePerHour));
            }
        }

        Console.WriteLine("\nPAYMENTS:");
        foreach (Employee e in employees)
        {
            Console.WriteLine($"{e.Name} - $ {e.Payment():F2}");
        }
    }
}
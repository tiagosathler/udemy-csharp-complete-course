namespace S06C78;

internal static class Program

{
    private const short MAX_EMPLOYEES = 10;
    private const double MIN_SALARY = 1320.00;

    private static readonly List<Employee> employees = new();

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        short numberOfRecords = RequestNumberOfRecords();

        for (int iteration = 0; iteration < numberOfRecords; iteration++)
        {
            Console.WriteLine($"\nEmployee #{iteration + 1}");
            short id = RequestIdField();
            string name = RequestNameField();
            double salary = RequestSalaryField();

            employees.Add(new Employee(id, name, salary));
        }

        Console.WriteLine("\nList of employees:");
        PrintEmployeesList();

        short idToIncreaseSalary = RequestIdToIncreaseSalary();
        double percentage = RequestPercentage();

        Employee employee = employees.Find(e => e.Id.Equals(idToIncreaseSalary))!;
        employee.IncreaseSalary(percentage);

        Console.WriteLine("\nUpdated list of employees:");
        PrintEmployeesList();
    }

    private static short RequestNumberOfRecords()
    {
        Console.Write("How many employees will be registered? ");
        short numberOfRecords = short.Parse(Console.ReadLine()!);

        while (numberOfRecords <= 0 || numberOfRecords > MAX_EMPLOYEES)
        {
            Console.Write($"Invalid number of records! It must be a number between 1 to {MAX_EMPLOYEES}. Enter number of records: ");
            numberOfRecords = short.Parse(Console.ReadLine()!);
        }

        return numberOfRecords;
    }

    private static short RequestIdField()
    {
        Console.Write("Id: ");
        short id = short.Parse(Console.ReadLine()!);

        while (id <= 0 || employees.Exists(e => e.Id == id))
        {
            Console.Write("Invalid Id! This id already exists or is less than or equal to 0. Id: ");
            id = short.Parse(Console.ReadLine()!);
        }

        return id;
    }

    private static string RequestNameField()
    {
        Console.Write("Name: ");
        string? name = Console.ReadLine();

        while (name == null || name.Trim().Length == 0 || employees.Exists(e => e.Name!.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            Console.Write("Invalid Name! It must be a non-empty word or non-registered name. Name: ");
            name = Console.ReadLine();
        }

        return name.Trim();
    }

    private static double RequestSalaryField()
    {
        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine()!);

        while (salary < MIN_SALARY)
        {
            Console.Write($"Invalid salary. It must be greater than or equal to the minimum wage of $ {MIN_SALARY}. Salary: ");
            salary = double.Parse(Console.ReadLine()!);
        }

        return salary;
    }

    private static void PrintEmployeesList()
    {
        Console.WriteLine("\n-------------------------");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("-------------------------\n");
    }

    private static short RequestIdToIncreaseSalary()
    {
        Console.Write("Enter the employee id that will have salary increase: ");
        short id = short.Parse(Console.ReadLine()!);

        while (!employees.Exists(e => e.Id == id))
        {
            Console.Write("Invalid Id! It does not exist in the database. Id: ");
            id = short.Parse(Console.ReadLine()!);
        }

        return id;
    }

    private static double RequestPercentage()
    {
        Console.Write("Enter the percentage: ");
        double percentage = double.Parse(Console.ReadLine()!);

        while (percentage <= 0)
        {
            Console.Write("Invalid percentage to increase salary! It must be greater than 0. Percentage: ");
            percentage = double.Parse(Console.ReadLine()!);
        }

        return percentage;
    }
}
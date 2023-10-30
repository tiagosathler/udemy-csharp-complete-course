namespace S17C242;

using Entities;
using Exceptions;

internal static class Program
{
    private const string DEFAULT_DIRECTORY = "files";
    private const string DEFAULT_FILE_NAME = "input.csv";

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        HashSet<Employee> employees = new();

        try
        {
            string path = GetDirectoryFullPath();

            List<string> contentOfLines = GetContentOfLinesFromDefaultFileInPath(path);

            employees = CreateEmployeeSetFromContentOfLines(contentOfLines);
        }
        catch (DomainException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }

        ProcessesEmployeeSet(employees);
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

    private static HashSet<Employee> CreateEmployeeSetFromContentOfLines(List<string> contentOfLines)
    {
        HashSet<Employee> employees = new();

        for (int line = 0; line < contentOfLines.Count; line++)
        {
            string[] fields = contentOfLines[line].Split(',');

            if (fields.Length != 3)
            {
                throw new DomainException($"Error on line {line + 1} of CSV file: format is invalid. It must only have the Name, Email and Salary fields");
            }

            if (string.IsNullOrWhiteSpace(fields[0]) || string.IsNullOrWhiteSpace(fields[1]))
            {
                throw new DomainException($"Error on line {line + 1} of CSV file: format is invalid. The Name and Email fields are required and cannot be empty or null");
            }

            string name = fields[0].Trim();

            string email = fields[1].Trim();

            if (!double.TryParse(fields[2], out double salary) || salary <= 0.0)
            {
                throw new DomainException($"Error on line {line + 1} of CSV file: format is invalid. The Salary field must be a number greater than 0.00");
            }

            employees.Add(new Employee(name, email, salary));
        }

        return employees;
    }

    private static void ProcessesEmployeeSet(HashSet<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("\x1b[1mNOT ENOUGH EMPLOYEES TO PROCESS. At least 1 are required.\x1b[0m");
            return;
        }

        PrintEmployees(employees);

        double baseSalary = GetBaseSalary();
        string letter = GetLetter();

        IEnumerable<string> emails = ListEmailsOfEmployeesWithSalaryAboveBaseValue(baseSalary, employees);
        double sumOfSalary = AddUpSalariesOfEmployeesWhoseNameBeginsWithLetter(letter, employees);

        PrintEmails(baseSalary, emails);
        PrintSumOfSalaries(letter, sumOfSalary);
    }

    private static void PrintEmployees(HashSet<Employee> employees)
    {
        Console.WriteLine("\n\x1b[1mSet of Employees:\x1b[0m");

        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee);
        }

        Console.WriteLine();
    }

    private static double GetBaseSalary()
    {
        double baseSalary;

        do
        {
            Console.Write("Enter salary: ");
        } while (!double.TryParse(Console.ReadLine(), out baseSalary) || baseSalary <= 0);

        return baseSalary;
    }

    private static string GetLetter()
    {
        string? letter;
        bool isValidLetter;

        do
        {
            Console.Write("Enter the first letter of employees' names to calculate the sum of their salaries: ");
            letter = Console.ReadLine();
            isValidLetter = !string.IsNullOrWhiteSpace(letter) && letter.Trim().ToLower()[0] >= 'a' && letter.Trim().ToLower()[0] <= 'z';
        } while (!isValidLetter);

        return letter!.Trim()[..1];
    }

    private static IEnumerable<string> ListEmailsOfEmployeesWithSalaryAboveBaseValue(double baseSalary, HashSet<Employee> employees)
    {
        return from employee in employees
               where employee.Salary >= baseSalary
               orderby employee.Email
               select employee.Email;
    }

    private static double AddUpSalariesOfEmployeesWhoseNameBeginsWithLetter(string letter, HashSet<Employee> employees)
    {
        return (from employee in employees
                where employee.Name.StartsWith(letter, StringComparison.CurrentCultureIgnoreCase)
                select employee.Salary)
               .DefaultIfEmpty()
               .Sum();
    }

    private static void PrintEmails(double baseSalary, IEnumerable<string> emails)
    {
        if (emails.Any())
        {
            Console.WriteLine($"\n\x1b[1mEmail of employees whose salary is more than ${baseSalary:F2}:\x1b[0m");

            foreach (string email in emails)
            {
                Console.WriteLine($"- {email}");
            }
        }
        else
        {
            Console.WriteLine($"\nThere aren't employees whose salary is more than ${baseSalary:F2}!");
        }
    }

    private static void PrintSumOfSalaries(string letter, double sumOfSalary)
    {
        if (sumOfSalary != 0.0)
        {
            Console.WriteLine($"\n\x1b[1mSum of salaries of employees whose names start with '{letter}': ${sumOfSalary:F2}");
        }
        else
        {
            Console.WriteLine($"\nThere aren't no employees whose names start with '{letter}'!");
        }
    }
}
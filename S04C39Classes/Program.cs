namespace S04S39Classes;

using S04C39Classes;
using System.Globalization;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        // Exercise01();
        Exercise02();
    }

    private static void Exercise01()
    {
        Rectangle rectangle = new Rectangle();
        Console.WriteLine("Entre com a largura e altura do retângulo:");
        rectangle.Width = double.Parse(Console.ReadLine()!);
        rectangle.Height = double.Parse(Console.ReadLine()!);

        Console.WriteLine("ÁREA = {0:F2}", rectangle.Area());
        Console.WriteLine("PERÍMETRO = {0:F2}", rectangle.Perimeter());
        Console.WriteLine("DIAGONAL = {0:F2}", rectangle.Diagonal());
    }

    private static void Exercise02()
    {
        Employee employee = new Employee();
        Console.Write("Nome: ");
        employee.Name = Console.ReadLine();
        Console.Write("Salário bruto: ");
        employee.GrossSalary = double.Parse(Console.ReadLine()!);
        Console.Write("Imposto: ");
        employee.Tax = double.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nFuncionário: {employee}");

        Console.Write("\nDigite a porcentagem para aumentar o salário: ");
        employee.IncreaseSalary(double.Parse(Console.ReadLine()!));

        Console.WriteLine($"\nFuncionário: {employee}");
    }
}
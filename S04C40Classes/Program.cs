using System.Globalization;

namespace S04C40Classes;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Exercise01();
    }

    private static void Exercise01()
    {
        Person p1 = new();
        Person p2 = new();

        Console.WriteLine("Dados da primeira pessoa:");
        Console.Write("Nome: ");
        p1.Name = Console.ReadLine();
        Console.Write("Idade: ");
        p1.Age = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Dados da segunda pessoa:");
        Console.Write("Nome: ");
        p2.Name = Console.ReadLine();
        Console.Write("Idade: ");
        p2.Age = int.Parse(Console.ReadLine()!);

        Console.Write("\nPessoa mais velha: ");
        if (p1.Age > p2.Age) Console.Write($"{p1.Name}");
        else Console.Write($"{p2.Name}");
    }
}
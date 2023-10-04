namespace S05C60;

using System.Globalization;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Entre com o número da conta: ");
        Account account = new(int.Parse(Console.ReadLine()!));

        Console.Write("Entre com o titular da conta: ");
        account.Holder = Console.ReadLine();

        Console.Write("Haverá depósito inicial (s/n)? ");
        string choice = Console.ReadLine()!.Trim().ToLower();

        if (choice.Length > 0 && choice[0] == 's')
        {
            Console.Write("Entre com o valor do depósito inicial: ");
            account.Deposit(double.Parse(Console.ReadLine()!));
        }

        Console.WriteLine($"\nDados da conta\n{account}\n");

        Console.Write("Entre com um valor para depósito: ");
        account.Deposit(double.Parse(Console.ReadLine()!));
        Console.WriteLine($"Dados da conta atualizada\n{account}\n");

        Console.Write("Entre com um valor para saque: ");
        account.Withdrawal(double.Parse(Console.ReadLine()!));
        Console.WriteLine($"Dados da conta atualizada\n{account}\n");
    }
}
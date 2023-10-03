namespace S04S39Classes;

using S04C39Classes;
using System.Globalization;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Exercise01();
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
}
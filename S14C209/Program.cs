using S14C209.Entities;

namespace S14C209;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CurrentCulture;

        Shape rectangle = new Rectangle(Color.White, 2.5, 6);
        Shape circle = new Circle(Color.Black, 9.1);

        Console.WriteLine(rectangle);
        Console.WriteLine(circle);
    }
}
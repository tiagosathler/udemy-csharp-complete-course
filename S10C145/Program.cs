using S10C145.Entities;
using S10C145.Entities.Enums;

namespace S10C145;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        List<Shape> shapes = new();

        int numberOfShapes = GetNumberOfShapes();

        for (int i = 1; i <= numberOfShapes; i++)
        {
            Console.WriteLine($"\n\x1b[1mShape {i} data:\x1b[0m");

            char typeOfShape = GetTypeOfShape();

            Color color = GetColor();

            if (typeOfShape == 'r')
            {
                double width = GetDimension("Width");
                double height = GetDimension("Height");
                shapes.Add(new Rectangle(color, width, height));
            }
            else if (typeOfShape == 'c')
            {
                double radius = GetDimension("Radius");
                shapes.Add(new Circle(color, radius));
            }
        }

        Console.WriteLine($"\n\x1b[1mSHAPE AREAS ({shapes.Count}):\x1b[0m");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"- {shape};");
        }

        Console.WriteLine($"\n\x1b[1mTOTAL AREA = {shapes.Sum(s => s.Area()):F2}\x1b[0m");
    }

    private static int GetNumberOfShapes()
    {
        int numberOfShapes;

        do
        {
            Console.Write("Enter the number of shapes: ");
        } while (!int.TryParse(Console.ReadLine(), out numberOfShapes) || numberOfShapes <= 0);

        return numberOfShapes;
    }

    private static char GetTypeOfShape()
    {
        char typeOfShape;

        do
        {
            Console.Write("Rectangle or Circule (r/c)? ");
        } while (
            !(char.TryParse(Console.ReadLine(), out typeOfShape)
            && (typeOfShape == 'r' || typeOfShape == 'c')));

        return typeOfShape;
    }

    private static Color GetColor()
    {
        Color color;

        string[] colorsName = Enum.GetNames<Color>();
        string? colorStr;

        do
        {
            Console.Write($"Color ({String.Join(", ", colorsName)})? ");
            colorStr = Console.ReadLine();
        } while (
            !(!String.IsNullOrWhiteSpace(colorStr)
            && Enum.TryParse(colorStr.Trim().ToUpper(), out color)));

        return color;
    }

    private static double GetDimension(string name)
    {
        double dimension;

        do
        {
            Console.Write($"{name}: ");
        } while (!double.TryParse(Console.ReadLine(), out dimension) || dimension <= 0.0);

        return dimension;
    }
}
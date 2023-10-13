using S10C145.Entities.Enums;

namespace S10C145.Entities;

internal sealed class Circle : Shape
{
    public double Radius { get; }

    public override string Name => "Circle";

    public Circle(Color color, double radius)
        : base(color)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(Radius, 2.0);
    }

    public override string ToString()
    {
        return $"{Name} - Radius = {Radius:F2} - Area = {Area():F2}";
    }
}
using S10C145.Entities.Enums;

namespace S10C145.Entities;

internal sealed class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public override string Name => "Rectangle";

    public Rectangle(Color color, double width, double height)
        : base(color)
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override string ToString()
    {
        return $"{Name} - Width = {Width:F2}, Height = {Height:F2} - Area = {Area():F2}";
    }
}
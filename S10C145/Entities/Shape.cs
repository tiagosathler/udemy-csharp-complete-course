using S10C145.Entities.Enums;

namespace S10C145.Entities;

internal abstract class Shape
{
    public Color Color { get; }
    public abstract string Name { get; }

    protected Shape(Color color)
    {
        Color = color;
    }

    public abstract double Area();
}
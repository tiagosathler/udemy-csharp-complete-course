namespace S14C209.Entities;

internal sealed class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(Color color, double width, double height) : base(color)
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
        return $"Rectangle: Width = {Width:F2}; Height = {Height:F2} - " + base.ToString();
    }
}
namespace S14C209.Entities;

internal sealed class Circle : Shape
{
    public double Radius { get; }

    public Circle(Color color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(Radius, 2.0);
    }

    public override string ToString()
    {
        return $"Circle: Radius = {Radius:F2} - " + base.ToString();
    }
}
namespace S04C39Classes;

internal class Rectangle
{
    public double Width;
    public double Height;

    public double Area()
    {
        return Width * Height;
    }

    public double Perimeter()
    {
        return (Width + Height) * 2;
    }

    public double Diagonal()
    {
        return Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
    }
}
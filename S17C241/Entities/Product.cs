namespace S17C241.Entities;

internal class Product
{
    public string Name { get; init; }
    public double Price { get; init; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override sealed string ToString()
    {
        return $"{Name} - $ {Price:F2}";
    }

    public override sealed bool Equals(object? obj)
    {
        return obj is Product otherProduct && otherProduct.Name.Equals(Name, StringComparison.OrdinalIgnoreCase);
    }

    public override sealed int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}
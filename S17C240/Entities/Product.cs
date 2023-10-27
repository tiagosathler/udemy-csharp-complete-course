namespace S17C237.Entities;

internal class Product
{
    public int Id { get; }

    public string Name { get; }

    public double Price { get; }

    public Category Category { get; }

    public Product(int id, string name, double price, Category category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public override sealed string ToString()
    {
        return $"{Id}, {Name}, ${Price:F2}, {Category?.Name ?? "category name not defined"}, {Category?.Tier ?? -1}";
    }

    public override sealed bool Equals(object? obj)
    {
        return obj is Product product &&
               Id == product.Id;
    }

    public override sealed int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
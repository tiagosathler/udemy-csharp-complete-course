namespace S17C237.Entities;

internal sealed class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double Price { get; set; }

    public Category? Category { get; set; }

    public Product()
    {
    }

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Product(int id, string name, double price, Category category) : this(id, name, price)
    {
        Category = category;
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, ${Price:F2}, {Category?.Name ?? "category name not defined"}, {Category?.Tier ?? -1}";
    }
}
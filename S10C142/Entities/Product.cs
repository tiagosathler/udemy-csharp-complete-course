namespace S10C142.Entities;

internal class Product
{
    public string Name { get; }
    public double Price { get; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual string Tag()
    {
        return $"{Name} $ {Price:F2}";
    }
}
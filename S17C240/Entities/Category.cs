namespace S17C237.Entities;

internal class Category
{
    public int Id { get; }

    public string Name { get; }

    public int Tier { get; }

    public Category(int id, string name, int tier)
    {
        Id = id;
        Name = name;
        Tier = tier;
    }

    public override sealed bool Equals(object? obj)
    {
        return obj is Category category &&
               Id == category.Id;
    }

    public override sealed int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
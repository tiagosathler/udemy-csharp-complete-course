namespace S17C237.Entities;

internal class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Tier { get; set; }

    public Category(int id, string name, int tier)
    {
        Id = id;
        Name = name;
        Tier = tier;
    }
}
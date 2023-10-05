namespace S06C72;

internal class Renter
{
    public string? Name { set; get; }
    public string? Email { set; get; }

    public override string ToString()
    {
        return $"Nome: {Name}; Email: {Email};";
    }
}
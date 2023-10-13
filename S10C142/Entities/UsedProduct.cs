namespace S10C142.Entities;

internal sealed class UsedProduct : Product
{
    public DateTime ManufactureDate { get; }

    public UsedProduct(string name, double price, DateTime manufactureDate)
        : base(name, price)
    {
        ManufactureDate = manufactureDate;
    }

    public override string Tag()
    {
        return $"{Name} (used) $ {Price:F2} (Manufacture date: {ManufactureDate:dd/MM/yyyy})";
    }
}
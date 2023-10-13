namespace S10C142.Entities;

internal sealed class ImportedProduct : Product
{
    public double CustomsFee { get; }

    public ImportedProduct(string name, double price, double customsFee)
        : base(name, price)
    {
        CustomsFee = customsFee;
    }

    public override string Tag()
    {
        return $"{Name} $ {Price + CustomsFee:F2} (Customs fee: $ {CustomsFee:F2})";
    }
}
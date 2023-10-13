namespace S10C146.Entities;

internal abstract class Taxpayer
{
    public string Name { get; }
    public double AnnualIncome { get; }

    protected Taxpayer(string name, double annualIncome)
    {
        Name = name;
        AnnualIncome = annualIncome;
    }

    public abstract double GetTaxesPaid();
}
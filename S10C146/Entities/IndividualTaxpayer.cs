namespace S10C146.Entities;

internal sealed class IndividualTaxpayer : Taxpayer
{
    private const double INCOME_LIMIT = 20000.00;
    private const double LOWER_INCOME_TAX_RATE = 0.15;
    private const double HIGHER_INCOME_TAX_RATE = 0.25;
    private const double DISCOUNT_RATE_HEALTHCARE = 0.50;

    public double HealthExpenditures { get; }

    public IndividualTaxpayer(string name, double annualIncome, double healthExpenditures)
        : base(name, annualIncome)
    {
        HealthExpenditures = healthExpenditures;
    }

    public override double GetTaxesPaid()
    {
        return (AnnualIncome
            * (AnnualIncome < INCOME_LIMIT ? LOWER_INCOME_TAX_RATE : HIGHER_INCOME_TAX_RATE))
            - (HealthExpenditures * DISCOUNT_RATE_HEALTHCARE);
    }

    public override string ToString()
    {
        return $"{Name}: $ {GetTaxesPaid():F2}";
    }
}
namespace S10C146.Entities;

internal sealed class LegalEntityTaxpayer : Taxpayer
{
    private const int EMPLOYEES_NUMBER_LIMIT = 10;
    private const double LOWER_INCOME_TAX_RATE = 0.14;
    private const double HIGHER_INCOME_TAX_RATE = 0.16;
    public int NumberOfEmployees { get; }

    public LegalEntityTaxpayer(string name, double annualIncome, int numberOfEmployees)
        : base(name, annualIncome)
    {
        NumberOfEmployees = numberOfEmployees;
    }

    public override double GetTaxesPaid()
    {
        return NumberOfEmployees > EMPLOYEES_NUMBER_LIMIT
            ? AnnualIncome * LOWER_INCOME_TAX_RATE
            : AnnualIncome * HIGHER_INCOME_TAX_RATE;
    }

    public override string ToString()
    {
        return $"{Name}: $ {GetTaxesPaid():F2}";
    }
}
namespace S10C140.Entities;

internal sealed class OutsourceEmployee : Employee
{
    private const double ADDITIONAL_TAX = 1.1;

    public double AdditionalCharge { get; set; }

    public OutsourceEmployee()
    {
    }

    public OutsourceEmployee(string name, int hours, double valuePerHour, double additionalCharge)
        : base(name, hours, valuePerHour)
    {
        AdditionalCharge = additionalCharge;
    }

    public override double Payment()
    {
        return base.Payment() + (AdditionalCharge * ADDITIONAL_TAX);
    }
}
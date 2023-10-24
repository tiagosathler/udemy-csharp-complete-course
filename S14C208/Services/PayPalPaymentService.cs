namespace S14C208.Services;

internal sealed class PayPalPaymentService : IPaymentService
{
    private const double MonthlySimpleInterestRate = 0.01;

    private const double PaymentFeeRate = 0.02;

    public double Interest(double amount, int months)
    {
        return amount * MonthlySimpleInterestRate * months;
    }

    public double PaymentFee(double amount)
    {
        return amount * PaymentFeeRate;
    }
}
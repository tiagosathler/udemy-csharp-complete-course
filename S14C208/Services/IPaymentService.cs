namespace S14C208.Services;

internal interface IPaymentService
{
    internal double Interest(double amount, int months);

    internal double PaymentFee(double amount);
}
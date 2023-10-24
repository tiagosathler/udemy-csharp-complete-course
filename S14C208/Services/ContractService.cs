using S14C208.Entities;

namespace S14C208.Services;

internal sealed class ContractService
{
    private readonly IPaymentService _paymentService;

    public ContractService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public void ProcessContract(Contract contract, int months)
    {
        double basicQuota = contract.Value / months;

        for (int monthCount = 1; monthCount <= months; monthCount++)
        {
            double amount = basicQuota + _paymentService.Interest(basicQuota, monthCount);

            amount += _paymentService.PaymentFee(amount);

            DateTime dueDate = contract.Date.AddMonths(monthCount);

            contract.AddInstallment(new Installment(dueDate, amount));
        }
    }
}
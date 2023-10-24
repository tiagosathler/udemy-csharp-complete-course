using S14C208.Entities;
using S14C208.Services;
using S14C208.UserInterface;

namespace S14C208;

internal static class Program
{
    internal static readonly string DTF = "dd/MM/yyyy";

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        UI.PrintHead();

        int number = UI.GetContractNumber();

        DateTime date = UI.GetContractDate();

        double value = UI.GetContractValue();

        int quantityOfInstallments = UI.GetQuantityOfInstallments();

        Contract contract = new(number, date, value);

        IPaymentService payPalService = new PayPalPaymentService();

        ContractService contractService = new(payPalService);

        contractService.ProcessContract(contract, quantityOfInstallments);

        UI.PrintContract(contract);
    }
}
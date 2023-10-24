using System.Text;

namespace S14C208.Entities;

internal sealed class Contract
{
    public int Number { get; }
    public DateTime Date { get; }
    public double Value { get; }
    public double TotalFunding => _installments.Sum(i => i.Amount);

    private readonly List<Installment> _installments = new();

    public Contract(int number, DateTime date, double value)
    {
        Number = number;
        Date = date;
        Value = value;
    }

    public void AddInstallment(Installment installment)
    {
        _installments.Add(installment);
    }

    public void RemoveInstallment(Installment installment)
    {
        _installments.Remove(installment);
    }

    public override string ToString()
    {
        StringBuilder sb = new("\n\x1b[1mCONTRACT SUMMARY:\x1b[0m\n\n");

        sb
            .Append("Number: ").Append(Number).AppendLine()
            .AppendLine("\nInstallments:");

        for (int i = 1; i <= _installments.Count; i++)
        {
            sb.Append('#').Append(i).Append(" - ").Append(_installments[i - 1]).AppendLine();
        }

        sb.Append("\n\x1b[1mTOTAL: $").Append(TotalFunding).Append("\x1b[0m").AppendLine();

        return sb.ToString();
    }
}
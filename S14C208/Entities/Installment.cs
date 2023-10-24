namespace S14C208.Entities;

internal sealed class Installment
{
    public DateTime DueDate { get; }
    public double Amount { get; }

    public Installment(DateTime dueDate, double amount)
    {
        DueDate = dueDate;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{DueDate.ToString(Program.DTF)} - Amount: ${Amount:F2}";
    }
}
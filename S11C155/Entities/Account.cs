using S11C155.Exceptions;

namespace S11C155.Entities;

internal sealed class Account
{
    public int Number { get; }
    public string Name { get; }
    public double Balance { get; private set; }
    public double WithdrawLimit { get; }

    public Account(int number, string name, double balance, double withdrawLimit)
    {
        Number = number;
        Name = name;
        Balance = balance;
        WithdrawLimit = withdrawLimit;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > WithdrawLimit)
        {
            throw new AccountException("Withdraw error: The amount exceeds withdraw limit");
        }
        if (Balance - amount < 0)
        {
            throw new AccountException("Withdraw error: Not enough balance");
        }

        Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account Number: {Number},"
            + $" Holder: {Name},"
            + $" Balance: ${Balance:F2},"
            + $" Withdraw Limit: ${WithdrawLimit:F2};";
    }
}
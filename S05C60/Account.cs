namespace S05C60
{
    internal class Account
    {
        private const double WITHDRAWAL_FEE = 5.0;

        public string? Holder { get; set; }

        public int Number { get; }

        public double Balance { get; private set; }

        public Account(int number)
        {
            Balance = 0;
            Number = number;
        }

        public Account(string holder, int number) : this(number)
        {
            Holder = holder;
        }

        public void Deposit(double value)
        {
            if (value > 0)
            {
                Balance += value;
            }
            else
            {
                Console.WriteLine("Depósito inválido!");
            }
        }

        public void Withdrawal(double amount)
        {
            if (Balance >= amount + WITHDRAWAL_FEE)
            {
                Balance -= amount + WITHDRAWAL_FEE;
            }
            else
            {
                Console.WriteLine("Não há saldo suficiente para sacar!");
            }
        }

        public override string ToString()
        {
            return $"Conta bancária número: {Number}; Titular: {Holder}; Saldo $ {Balance:F2}";
        }
    }
}
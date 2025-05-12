namespace Inheritance
{
    public abstract class Transaction
    {
        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Сумма не может быть отрицательной.");
                }

                _amount = value;
            }
        }

        protected Transaction(decimal amount)
        {
            Amount = amount;
        }

        public abstract void Process();

        public virtual bool HasSufficientFunds(decimal balance)
        {
            return balance >= Amount;
        }
    }
}

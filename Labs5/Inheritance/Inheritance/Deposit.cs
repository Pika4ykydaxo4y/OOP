namespace Inheritance
{
    public class Deposit : Transaction
    {
        public Deposit(decimal amount) : base(amount)
        {
        }

        public override void Process()
        {
            Console.WriteLine("Внесение денег завершено");
        }

        public override bool HasSufficientFunds(decimal balance)
        {
            // Внесение всегда возможно
            return true;
        }
    }
}

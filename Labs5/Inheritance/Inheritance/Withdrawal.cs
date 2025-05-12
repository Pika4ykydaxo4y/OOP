namespace Inheritance
{
    public class Withdrawal : Transaction
    {
        public Withdrawal(decimal amount) : base(amount)
        {
        }

        public override void Process()
        {
            Console.WriteLine("Снятие денег завершено");
        }
    }
}

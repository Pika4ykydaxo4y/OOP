namespace Inheritance
{
    public class Transfer : Transaction
    {
        public Transfer(decimal amount) : base(amount)
        {
        }

        public override void Process()
        {
            Console.WriteLine("Перевод средств завершен");
        }
    }
}

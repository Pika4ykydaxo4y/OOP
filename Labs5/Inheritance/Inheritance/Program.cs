using System;

namespace Inheritance
{
    internal class Program
    {
        private static void Main()
        {
            decimal currentBalance = 1000m;

            // Внесение
            var deposit = new Deposit(300m);
            if (deposit.HasSufficientFunds(currentBalance))
            {
                deposit.Process();
                currentBalance += deposit.Amount;
            }

            // Снятие
            var withdrawal = new Withdrawal(200m);
            if (withdrawal.HasSufficientFunds(currentBalance))
            {
                withdrawal.Process();
                currentBalance -= withdrawal.Amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств для снятия.");
            }

            // Перевод
            var transfer = new Transfer(900m);
            if (transfer.HasSufficientFunds(currentBalance))
            {
                transfer.Process();
                currentBalance -= transfer.Amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств для перевода.");
            }

            Console.WriteLine($"\nИтоговый баланс: {currentBalance}");
        }
    }
}

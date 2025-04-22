using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Создаем новый театральный билет
            TheaterTicket ticket = new TheaterTicket("Лебединое озеро", new DateTime(2025, 12, 03, 19, 30,  00, 00), 500.00m, 100);

            // Отображаем информацию о билете
            Console.WriteLine(ticket.GetTicketInfo());

            // Бронируем билет
            if (ticket.ReserveTicket())
            {
                Console.WriteLine("Билет успешно забронирован!");
            }
            else
            {
                Console.WriteLine("Нет доступных билетов для бронирования.");
            }

            // Отображаем информацию о билете после бронирования
            Console.WriteLine(ticket.GetTicketInfo());

            // Отменяем бронирование
            ticket.CancelReservation();
            Console.WriteLine("Бронирование успешно отменено!");

            // Отображаем информацию о билете после отмены бронирования
            Console.WriteLine(ticket.GetTicketInfo());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}

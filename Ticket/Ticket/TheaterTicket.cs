using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TheaterTicket
{
    private string eventName;
    private DateTime eventDateTime;
    private decimal ticketPrice;
    private bool isReserved = false;
    private int numberOfTickets;

    public string EventName => eventName;
    public DateTime EventDateTime => eventDateTime;
    public decimal TicketPrice => ticketPrice;
    public bool IsReserved => isReserved;
    public int NumberOfTickets => numberOfTickets;

    public TheaterTicket(string eventName, DateTime eventDateTime, decimal ticketPrice, int numberOfTickets)
    {
        if (string.IsNullOrWhiteSpace(eventName))
            throw new ArgumentException("Название спектакля не может быть пустым.");
        if (ticketPrice <= 0)
            throw new ArgumentException("Цена билета должна быть больше нуля.");
        if (numberOfTickets < 0)
            throw new ArgumentException("Количество билетов не может быть отрицательным.");

        this.eventName = eventName;
        this.eventDateTime = eventDateTime;
        this.ticketPrice = ticketPrice;
        this.numberOfTickets = numberOfTickets;
    }

    public bool ReserveTicket()
    {
        if (numberOfTickets > 0)
        {
            numberOfTickets--;
            isReserved = true;
            return true;
        }
        return false;
    }

    public void CancelReservation()
    {
        if (!isReserved)
            throw new InvalidOperationException("Бронирование не было сделано.");

        numberOfTickets++;
        isReserved = false;
    }

    public string GetTicketInfo()
    {
        return $"Событие: \"{eventName}\", Дата: {eventDateTime:dd.MM.yyyy HH:mm}, Цена: {ticketPrice:F2}, Доступных билетов: {numberOfTickets}";
    }
}
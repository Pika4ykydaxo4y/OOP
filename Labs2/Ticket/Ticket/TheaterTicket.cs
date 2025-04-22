public class TheaterTicket
{
    //Приватные поля
    private readonly string _eventName;
    private readonly DateTime _eventDateTime;
    private readonly decimal _ticketPrice;
    private bool _isReserved = false;
    private int _numberOfTickets;

    //Свойства(только читать)
    public string EventName => _eventName;
    public DateTime EventDateTime => _eventDateTime;
    public decimal TicketPrice => _ticketPrice;
    public bool IsReserved => _isReserved;
    public int NumberOfTickets => _numberOfTickets;

    /// <summary>
    /// Создает новый экземпляр театрального билета.
    /// </summary>
    public TheaterTicket(string eventName, DateTime eventDateTime, decimal ticketPrice, int numberOfTickets)
    {
        if (string.IsNullOrWhiteSpace(eventName))
            throw new ArgumentException("Название спектакля не может быть пустым.");
        if (ticketPrice <= 0)
            throw new ArgumentException("Цена билета должна быть больше нуля.");
        if (numberOfTickets < 0)
            throw new ArgumentException("Количество билетов не может быть отрицательным.");

        //Присваиваем значения
        this._eventName = eventName;
        this._eventDateTime = eventDateTime;
        this._ticketPrice = ticketPrice;
        this._numberOfTickets = numberOfTickets;
    }
    /// <summary>
    //Резервируем, если получается то true, если нет то возвращаем false.
    /// <summary>
    public bool ReserveTicket()
    {
        if (_numberOfTickets > 0)
        {
            _numberOfTickets--;
            _isReserved = true;
            return true;
        }
        return false;
    }
    /// <summary>
    //Возвращаем билет и отменяем бронь
    /// <summary>
    public void CancelReservation()
    {
        if (!_isReserved)
            throw new InvalidOperationException("Бронирование не было сделано.");

        _numberOfTickets++;
        _isReserved = false;
    }

    public string GetTicketInfo()
    {
        return $"Событие: \"{_eventName}\", Дата: {_eventDateTime:dd.MM.yyyy HH:mm}, Цена: {_ticketPrice:F2}, Доступных билетов: {_numberOfTickets}";
    }
}
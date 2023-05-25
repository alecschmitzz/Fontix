namespace Fontix.Models;

public class Ticket
{
    public int Id { get; private set; }
    public int EventId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime DatetimeStart { get; private set; }
    public DateTime DatetimeEnd { get; private set; }
    public DateTime DatetimeView { get; private set; }
    public int Amount { get; private set; }

    public Ticket(int id, int eventId, string? name, decimal price, DateTime datetimeStart, DateTime datetimeEnd,
        DateTime datetimeView, int amount)
    {
        Id = id;
        EventId = eventId;
        Name = name;
        Price = price;
        DatetimeStart = datetimeStart;
        DatetimeEnd = datetimeEnd;
        DatetimeView = datetimeView;
        Amount = amount;
    }
}
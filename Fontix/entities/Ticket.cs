namespace Fontix.entities;

public class Ticket
{
    public int id { get; set; }
    public int EventId { get; set; }
    public decimal price { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
    public DateTime DateTimeView { get; set; }
    public int amount { get; set; }
}
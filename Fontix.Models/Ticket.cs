namespace Fontix.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int EventId { get; set; }
    public decimal Price { get; set; }
    public DateTime DatetimeStart { get; set; }
    public DateTime DatetimeEnd { get; set; }
    public DateTime DatetimeView { get; set; }
    public int Amount { get; set; }
}
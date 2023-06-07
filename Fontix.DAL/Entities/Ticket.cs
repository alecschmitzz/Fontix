namespace Fontix.DAL.Entities;

public class Ticket
{
    public int id { get; private set; }
    private int? alias_ticket_id { get; set; }
    private string? name { get; set; }
    private string? alias_ticket_name { get; set; }
    private int event_id { get; set; }
    private decimal price { get; set; }
    private DateTime datetime_start { get; set; }
    private DateTime datetime_end { get; set; }
    private DateTime datetime_view { get; set; }
    private DateTime? alias_datetime_view { get; set; }
    private int amount { get; set; }

    public Ticket()
    {
    }

    public Ticket(int id, string? name, int eventId, decimal price, DateTime datetimeStart, DateTime datetimeEnd,
        DateTime datetimeView, int amount)
    {
        this.id = id;
        this.name = name;
        event_id = eventId;
        this.price = price;
        datetime_start = datetimeStart;
        datetime_end = datetimeEnd;
        datetime_view = datetimeView;
    }

    public Fontix.Models.Ticket ConvertToModel()
    {
        return new Models.Ticket(id, event_id, name, price, datetime_start, datetime_end, datetime_view, amount);
    }

    public void SetAlias()
    {
        id = (int)alias_ticket_id;
        name = alias_ticket_name;
        datetime_view = (DateTime)alias_datetime_view;
    }
}
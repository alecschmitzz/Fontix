namespace fontix_logic.LogicModels;

public class Ticket
{
    public int id { get; set; }
    public string name { get; set; }
    public int event_id { get; set; }
    public decimal price { get; set; }
    public DateTime datetime_start { get; set; }
    public DateTime datetime_end { get; set; }
    public DateTime datetime_view { get; set; }
    public int amount { get; set; }

    /// <summary>
    /// CTOR for DTO
    /// </summary>
    /// <param name="DTOTicket"></param>
    public Ticket(fontix_data.Entities.Ticket DTOTicket)
    {
        id = DTOTicket.id;
        name = DTOTicket.name;
        event_id = DTOTicket.event_id;
        price = DTOTicket.price;
        datetime_start = DTOTicket.datetime_start;
        datetime_end = DTOTicket.datetime_end;
        datetime_view = DTOTicket.datetime_view;
        amount = DTOTicket.amount;
    }

    public Ticket(
        int id,
        string name,
        int eventId,
        decimal price,
        DateTime datetimeStart,
        DateTime datetimeEnd,
        DateTime datetimeView,
        int amount)
    {
        this.id = id;
        this.name = name;
        event_id = eventId;
        this.price = price;
        datetime_start = datetimeStart;
        datetime_end = datetimeEnd;
        datetime_view = datetimeView;
        this.amount = amount;
    }
}
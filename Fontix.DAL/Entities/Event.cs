namespace Fontix.DAL.Entities;

public class Event
{
    public int id { get; set; }
    public int alias_event_id { get; set; }
    public int organiser_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public virtual List<Ticket> Tickets { get; set; }

    public Event()
    {
        Tickets = new List<Ticket>();
    }
}
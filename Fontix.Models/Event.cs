namespace Fontix.Models;

public class Event
{
    public int Id { get; set; }
    public int OrganiserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Ticket> Tickets { get; set; }

    public Event()
    {
        Tickets = new List<Ticket>();
    }
}
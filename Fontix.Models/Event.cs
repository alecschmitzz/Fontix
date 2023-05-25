namespace Fontix.Models;

public class Event
{
    public int Id { get; private set; }
    public int OrganiserId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<Ticket> Tickets { get; private set; }

    public Event()
    {
        Tickets = new List<Ticket>();
    }

    public Event(int id, int organiserId, string name, string description, List<Ticket> tickets)
    {
        Id = id;
        OrganiserId = organiserId;
        Name = name;
        Description = description;
        Tickets = tickets;
    }
}
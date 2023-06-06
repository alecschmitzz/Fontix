namespace Fontix.Models;

public class Event
{
    public int Id { get; private set; }
    public int OrganisationId { get; private set; }
    public string Name { get; private set; }
    public string Venue { get; private set; }
    public string Description { get; private set; }
    public DateTime DateTimeView { get; private set; }
    public IReadOnlyList<Ticket> Tickets { get; private set; }

    public Event()
    {
        Tickets = new List<Ticket>();
    }

    public Event(int id, int organisationId, string name, string venue, string description, DateTime datetimeView,
        List<Ticket> tickets)
    {
        Id = id;
        OrganisationId = organisationId;
        Name = name;
        Venue = venue;
        Description = description;
        DateTimeView = datetimeView;
        Tickets = tickets;
    }
}
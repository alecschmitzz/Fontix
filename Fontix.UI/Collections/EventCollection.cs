using Fontix.UI.Models;

namespace Fontix.UI.Collections;

public class EventCollection
{
    private readonly List<Event> _events;

    public EventCollection()
    {
        _events = new List<Event>();
    }

    public EventCollection(List<Event> events)
    {
        _events = events;
    }

    public EventCollection(List<Fontix.Models.Event> events)
    {
        foreach (var myEvent in events)
        {
            List<Ticket> uiTickets = new List<Ticket>();
            foreach (var ticket in myEvent.Tickets)
            {
                uiTickets.Add(new Ticket(ticket.Id, ticket.EventId, ticket.Name, ticket.Price, ticket.DatetimeStart,
                    ticket.DatetimeEnd, ticket.DatetimeView, ticket.Amount));
            }

            Add(new Event(myEvent.Id, myEvent.OrganiserId, myEvent.Name, myEvent.Description, myEvent.DateTimeView, uiTickets));
        }
    }

    public List<Event> Get()
    {
        return _events;
    }

    public void Add(Event myEvent)
    {
        _events.Add(myEvent);
    }
}
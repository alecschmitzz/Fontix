using Fontix.UI.Models;

namespace Fontix.UI.Collections;

public class TicketCollection
{
    private readonly List<Ticket> _tickets = new List<Ticket>();

    public TicketCollection()
    {
    }

    public TicketCollection(List<Ticket> tickets)
    {
        _tickets = tickets;
    }

    public TicketCollection(List<Fontix.Models.Ticket> tickets)
    {
        foreach (var ticket in tickets)
        {
            Add(new Ticket(ticket.Id, ticket.EventId, ticket.Name, ticket.Price, ticket.DatetimeStart,
                ticket.DatetimeEnd, ticket.DatetimeView, ticket.Amount));
        }
    }

    public List<Ticket> Get()
    {
        return _tickets;
    }

    public void Add(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
}
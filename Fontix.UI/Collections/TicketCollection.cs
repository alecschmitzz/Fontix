using Fontix.UI.Models;

namespace Fontix.UI.Collections;

public class TicketCollection
{
    private List<Ticket> _tickets = new List<Ticket>();

    public TicketCollection()
    {
    }

    public TicketCollection(IReadOnlyList<Ticket> tickets)
    {
        _tickets = tickets.ToList();
    }

    public TicketCollection(IReadOnlyList<Fontix.Models.Ticket> tickets)
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
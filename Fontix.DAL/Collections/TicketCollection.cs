using System.Collections;
using Fontix.DAL.Entities;

namespace Fontix.DAL.Collections;

public class TicketCollection
{
    private readonly List<Ticket> _tickets;

    public TicketCollection()
    {
        _tickets = new List<Ticket>();
    }

    public TicketCollection(List<Ticket> tickets)
    {
        _tickets = tickets;
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
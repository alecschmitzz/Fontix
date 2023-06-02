using Fontix.DAL.Collections;

namespace Fontix.DAL.Entities;

public class Event
{
    public int id { get; private set; }
    private int? alias_event_id;
    private int organisation_id;
    private string name;
    private string description;
    private DateTime datetime_view;
    public TicketCollection Tickets { get; private set; }

    public Event()
    {
        Tickets = new TicketCollection();
    }

    public Event(int id, int organisationId, string name, string description, DateTime datetimeView, List<Ticket>? tickets)
    {
        this.id = id;
        this.organisation_id = organisationId;
        this.name = name;
        this.description = description;
        this.datetime_view = datetimeView;
        // Tickets = new TicketCollection(tickets);
    }

    public Fontix.Models.Event ConvertToModel()
    {
        List<Fontix.Models.Ticket> modelTickets = new List<Fontix.Models.Ticket>();

        foreach (var ticket in Tickets.Get())
        {
            modelTickets.Add(ticket.ConvertToModel());
        }

        return new Models.Event(id, organisation_id, name, description, datetime_view, modelTickets);
    }

    public void SetAlias()
    {
        id = (int)alias_event_id;
    }
}
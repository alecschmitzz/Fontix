using Fontix.UI.Collections;
using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class Event
{
    public int Id { get; private set; }
    public int OrganisationId { get; private set; }
    public string Name { get; private set; }
    public string Venue { get; private set; }
    public string? Description { get; private set; }
    public DateTime DateTimeView { get; private set; }
    public TicketCollection Tickets { get; private set; }

    public Event()
    {
        Tickets = new TicketCollection(); // Initialize the Tickets property
    }

    public Event(CreateEventBindingModel model)
    {
        Id = 0;
        OrganisationId = model.OrganisationId;
        Name = model.Name;
        Venue = model.Venue;
        Description = model.Description;
        DateTimeView = model.DateTimeView;
        Tickets = new TicketCollection();
    }

    public Event(EditEventBindingModel model)
    {
        Id = model.Id;
        OrganisationId = 0;
        Name = model.Name;
        Venue = model.Venue;
        Description = model.Description;
        DateTimeView = model.DateTimeView;
        Tickets = new TicketCollection();
    }

    public Event(int id, int organisationId, string name, string venue, string? description, DateTime datetimeView,
        List<Ticket> tickets)
    {
        Id = id;
        OrganisationId = organisationId;
        Name = name;
        Venue = venue;
        Description = description;
        DateTimeView = datetimeView;
        Tickets = new TicketCollection(tickets);
    }

    public Event(Fontix.Models.Event logicEvent)
    {
        Id = logicEvent.Id;
        OrganisationId = logicEvent.OrganisationId;
        Name = logicEvent.Name;
        Venue = logicEvent.Venue;
        Description = logicEvent.Description;
        DateTimeView = logicEvent.DateTimeView;
        Tickets = new TicketCollection(logicEvent.Tickets);
    }

    public Fontix.Models.Event ConvertToModel()
    {
        var modelTickets = new List<Fontix.Models.Ticket>();

        foreach (var ticket in Tickets.Get())
        {
            modelTickets.Add(ticket.ConvertToModel());
        }

        return new Fontix.Models.Event(Id, OrganisationId, Name, Venue, Description, DateTimeView, modelTickets);
    }
}
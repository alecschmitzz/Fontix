using Fontix.UI.Collections;
using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class Event
{
    public int Id { get; private set; }
    public int OrganiserId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public DateTime DateTimeView { get; private set; }
    public TicketCollection Tickets { get; private set; }

    public Event()
    {
        Tickets = new TicketCollection(); // Initialize the Tickets property
    }

    public Event(EventBindingModel model)
    {
        Id = model.Id;
        OrganiserId = model.OrganiserId;
        Name = model.Name;
        Description = model.Description;
        Tickets = new TicketCollection();
    }

    public Event(int id, int organiserId, string name, string? description, DateTime datetimeView, List<Ticket> tickets)
    {
        Id = id;
        OrganiserId = organiserId;
        Name = name;
        Description = description;
        DateTimeView = datetimeView;
        Tickets = new TicketCollection(tickets);
    }

    public Event(Fontix.Models.Event logicEvent)
    {
        Id = logicEvent.Id;
        OrganiserId = logicEvent.OrganiserId;
        Name = logicEvent.Name;
        Description = logicEvent.Description;
        Tickets = new TicketCollection(logicEvent.Tickets);
    }

    public Fontix.Models.Event ConvertToModel()
    {
        var modelTickets = new List<Fontix.Models.Ticket>();

        foreach (var ticket in Tickets.Get())
        {
            modelTickets.Add(ticket.ConvertToModel());
        }

        return new Fontix.Models.Event(Id, OrganiserId, Name, Description, DateTimeView, modelTickets);
    }
}
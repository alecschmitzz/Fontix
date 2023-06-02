using Fontix.UI.Collections;
using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class Organisation
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public EventCollection Events { get; private set; }

    public Organisation()
    {
        Events = new EventCollection(); // Initialize the Tickets property
    }

    public Organisation(OrganisationBindingModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Events = new EventCollection();
    }

    public Organisation(int id, string name, List<Event> events)
    {
        Id = id;
        Name = name;
        Events = new EventCollection(events);
    }

    public Organisation(Fontix.Models.Organisation logicOrganisation)
    {
        Id = logicOrganisation.Id;
        Name = logicOrganisation.Name;
        Events = new EventCollection(logicOrganisation.Events);
    }

    public Fontix.Models.Organisation ConvertToModel()
    {
        var modelEvents = new List<Fontix.Models.Event>();

        foreach (var myEvent in Events.Get())
        {
            modelEvents.Add(myEvent.ConvertToModel());
        }

        return new Fontix.Models.Organisation(Id, Name, modelEvents);
    }
}
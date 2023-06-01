using Fontix.UI.Collections;
using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class Organiser
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public EventCollection Events { get; private set; }

    public Organiser()
    {
        Events = new EventCollection(); // Initialize the Tickets property
    }

    public Organiser(OrganiserBindingModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Events = new EventCollection();
    }

    public Organiser(int id, string name, List<Event> events)
    {
        Id = id;
        Name = name;
        Events = new EventCollection(events);
    }

    public Organiser(Fontix.Models.Organiser logicOrganiser)
    {
        Id = logicOrganiser.Id;
        Name = logicOrganiser.Name;
        Events = new EventCollection(logicOrganiser.Events);
    }

    public Fontix.Models.Organiser ConvertToModel()
    {
        var modelEvents = new List<Fontix.Models.Event>();

        foreach (var myEvent in Events.Get())
        {
            modelEvents.Add(myEvent.ConvertToModel());
        }

        return new Fontix.Models.Organiser(Id, Name, modelEvents);
    }
}
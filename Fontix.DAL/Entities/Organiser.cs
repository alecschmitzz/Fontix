using Fontix.DAL.Collections;

namespace Fontix.DAL.Entities;

public class Organisation
{
    public int id { get; private set; }
    public string name { get; private set; }
    public EventCollection Events { get; private set; }

    public Organisation()
    {
        Events = new EventCollection();
    }

    public Organisation(int id, string name, List<Event> events)
    {
        this.id = id;
        this.name = name;
        Events = new EventCollection(events);
    }

    public Fontix.Models.Organisation ConvertToModel()
    {
        List<Fontix.Models.Event> modelEvents = new List<Fontix.Models.Event>();

        foreach (var myEvent in Events.Get())
        {
            modelEvents.Add(myEvent.ConvertToModel());
        }

        return new Models.Organisation(id, name, modelEvents);
    }
}
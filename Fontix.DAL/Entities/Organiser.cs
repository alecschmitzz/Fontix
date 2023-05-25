using Fontix.DAL.Collections;

namespace Fontix.DAL.Entities;

public class Organiser
{
    public int id { get; private set; }
    public string name { get; private set; }
    public EventCollection Events { get; private set; }

    public Organiser()
    {
        Events = new EventCollection();
    }

    public Organiser(int id, string name, List<Event> events)
    {
        this.id = id;
        this.name = name;
        Events = new EventCollection(events);
    }

    public Fontix.Models.Organiser ConvertToModel()
    {
        List<Fontix.Models.Event> modelEvents = new List<Fontix.Models.Event>();

        foreach (var myEvent in Events.Get())
        {
            modelEvents.Add(myEvent.ConvertToModel());
        }

        return new Models.Organiser(id, name, modelEvents);
    }
}
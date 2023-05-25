using Fontix.DAL.Entities;

namespace Fontix.DAL.Collections;

public class EventCollection
{
    private readonly List<Event> _events;

    public EventCollection()
    {
        _events = new List<Event>();
    }

    public EventCollection(List<Event> events)
    {
        _events = events;
    }

    public List<Event> Get()
    {
        return _events;
    }

    public void Add(Event myEvent)
    {
        _events.Add(myEvent);
    }
}


using Fontix.UI.Models;

namespace Fontix.UI.Collections;

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
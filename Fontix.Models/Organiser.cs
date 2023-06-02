namespace Fontix.Models;

public class Organisation
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Event> Events { get; private set; }

    public Organisation()
    {
        Events = new List<Event>();
    }

    public Organisation(int id, string name, List<Event> events)
    {
        Id = id;
        Name = name;
        Events = events;
    }
}
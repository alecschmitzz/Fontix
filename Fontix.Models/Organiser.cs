namespace Fontix.Models;

public class Organiser
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public virtual List<Event> Events { get; private set; }

    public Organiser()
    {
        Events = new List<Event>();
    }

    public Organiser(int id, string name, List<Event> events)
    {
        Id = id;
        Name = name;
        Events = events;
    }
}
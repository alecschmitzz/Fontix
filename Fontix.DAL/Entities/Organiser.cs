namespace Fontix.DAL.Entities;

public class Organiser
{
    public int id { get; set; }
    public string name { get; set; }
    public virtual List<Event> Events { get; set; }

    public Organiser()
    {
        Events = new List<Event>();
    }
}
namespace Fontix.Models;

public class Organiser
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Event> Events { get; set; }

    public Organiser()
    {
        Events = new List<Event>();
    }
}

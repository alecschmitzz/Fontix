namespace Fontix.Models;

public class Organisation
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Event> Events { get; private set; }
    public List<User> Users { get; private set; }

    public Organisation()
    {
        Events = new List<Event>();
        Users = new List<User>();
    }

    public Organisation(int id, string name, List<Event> events, List<User> users)
    {
        Id = id;
        Name = name;
        Events = events;
        Users = users;
    }
}
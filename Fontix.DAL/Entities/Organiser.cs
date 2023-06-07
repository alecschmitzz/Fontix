using Fontix.DAL.Collections;

namespace Fontix.DAL.Entities;

public class Organisation
{
    public int id { get; private set; }
    public string name { get; private set; }
    public EventCollection Events { get; private set; }
    public UserCollection Users { get; private set; }

    public Organisation()
    {
        Events = new EventCollection();
        Users = new UserCollection();
    }

    public Organisation(int id, string name, List<Event> events, List<User> users)
    {
        this.id = id;
        this.name = name;
        Events = new EventCollection(events);
        Users = new UserCollection(users);
    }

    public Fontix.Models.Organisation ConvertToModel()
    {
        var modelEvents = Events.Get().Select(myEvent => myEvent.ConvertToModel()).ToList();
        var modelUsers = Users.Get().Select(user => user.ConvertToModel()).ToList();

        return new Models.Organisation(id, name, modelEvents, modelUsers);
    }
}
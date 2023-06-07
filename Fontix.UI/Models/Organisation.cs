using Fontix.UI.Collections;
using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class Organisation
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public EventCollection Events { get; private set; }
    public UserCollection Users { get; private set; }

    public Organisation()
    {
        Events = new EventCollection(); // Initialize the Tickets property
        Users = new UserCollection(); // Initialize the Tickets property
    }

    public Organisation(CreateOrganisationBindingModel model)
    {
        Id = 0;
        Name = model.Name;
        Events = new EventCollection();
        Users = new UserCollection();
    }
    
    public Organisation(EditOrganisationBindingModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Events = new EventCollection();
        Users = new UserCollection();
    }

    public Organisation(int id, string name, List<Event> events, List<User> users)
    {
        Id = id;
        Name = name;
        Events = new EventCollection(events);
        Users = new UserCollection(users);
    }

    public Organisation(Fontix.Models.Organisation logicOrganisation)
    {
        Id = logicOrganisation.Id;
        Name = logicOrganisation.Name;
        Events = new EventCollection(logicOrganisation.Events);
        Users = new UserCollection(logicOrganisation.Users);
    }

    public Fontix.Models.Organisation ConvertToModel()
    {
        var modelEvents = Events.Get().Select(myEvent => myEvent.ConvertToModel()).ToList();

        var modelUsers = Users.Get().Select(user => user.ConvertToModel()).ToList();

        return new Fontix.Models.Organisation(Id, Name, modelEvents, modelUsers);
    }
}
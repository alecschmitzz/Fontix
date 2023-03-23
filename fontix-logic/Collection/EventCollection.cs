using fontix_data.Data;

namespace fontix_logic.Collection;

public class EventController
{
    public async Task<List<LogicModels.Event>> GetAllEvents(IEventData data)
    {
        List<fontix_data.Entities.Event> entitylist = new List<fontix_data.Entities.Event>();

        entitylist = (List<fontix_data.Entities.Event>)await data.GetEvents();

        List<LogicModels.Event> events = new List<LogicModels.Event>();

        foreach (fontix_data.Entities.Event myEvent in entitylist)
        {
            events.Add(new LogicModels.Event(myEvent));
        }

        return events;
    }

    public async Task<LogicModels.Event> GetEvent(IEventData data, int id)
    {
        return new LogicModels.Event(await data.GetEvent(id));
    }

    public async Task InsertEvent(IEventData data, LogicModels.Event myEvent)
    {
        fontix_data.Entities.Event insertEvent = new fontix_data.Entities.Event()
        {
            organiser_id = myEvent.organiser_id,
            name = myEvent.name,
            description = myEvent.description,
        };

        await data.InsertEvent(insertEvent);
    }

    public async Task UpdateEvent(IEventData data, LogicModels.Event myEvent)
    {
        fontix_data.Entities.Event updateEvent = new fontix_data.Entities.Event()
        {
            id = myEvent.id,
            organiser_id = myEvent.organiser_id,
            name = myEvent.name,
            description = myEvent.description,
        };

        await data.UpdateEvent(updateEvent);
    }

    public async Task DeleteEvent(IEventData data, int id)
    {
        await data.DeleteEvent(id);
    }
}
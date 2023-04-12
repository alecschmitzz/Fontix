using Fontix.IBLL.Collections;
using Fontix.IDAL.Data;
using Fontix.Models;

namespace Fontix.BLL.Collections;

public class EventCollection : IEventCollection
{
    private readonly IEventDal _data;

    public EventCollection(IEventDal data)
    {
        _data = data;
    }

    public async Task<List<Event>> GetAllEvents()
    {
        var events = await _data.GetEvents();
        return events.ToList();
    }

    public async Task<Event> GetEvent(int id)
    {
        return await _data.GetEvent(id);
    }
    
    public async Task<Event> GetEventWithReference(int id)
    {
        return await _data.GetEventWithReference(id);
    }

    public async Task InsertEvent(Event myEvent)
    {
        // var workspaceId = event.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = event.UserId ?? throw new InvalidInputException("userId is empty");
        
        await _data.InsertEvent(myEvent);
    }

    public async Task UpdateEvent(Event myEvent)
    {
        //check for empty input
        //TODO: check input for admin stuff
        //TODO: check input if time is allowed etc.
        // var workspaceId = event.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = event.UserId ?? throw new InvalidInputException("userId is empty");

        
        await _data.UpdateEvent(myEvent);
    }

    public async Task DeleteEvent(int id)
    {
        await _data.DeleteEvent(id);
    }
}
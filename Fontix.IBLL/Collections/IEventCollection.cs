using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface IEventCollection
{
    Task<List<Event>> GetAllEvents();
    Task<Event> GetEvent(int id);
    Task InsertEvent(Event myEvent);
    Task UpdateEvent(Event myEvent);
    Task DeleteEvent(int id);
}
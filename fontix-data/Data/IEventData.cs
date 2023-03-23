using fontix_data.Entities;

namespace fontix_data.Data;

public interface IEventData
{
    Task DeleteEvent(int id);
    Task<Event> GetEvent(int id);
    Task<IEnumerable<Event>> GetEvents();
    Task InsertEvent(Event myEvent);
    Task UpdateEvent(Event myEvent);
}
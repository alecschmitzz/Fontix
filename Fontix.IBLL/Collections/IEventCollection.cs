using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface IEventCollection
{
    Task<List<Event>> GetAllEvents();
    Task<List<Event>> GetOrganisationEvents(int id);
    Task<Event> GetEvent(int id);
    Task<Event> GetEventWithTickets(int id);
    Task InsertEvent(Event myEvent);
    Task UpdateEvent(Event myEvent);
    Task DeleteEvent(int id);
}
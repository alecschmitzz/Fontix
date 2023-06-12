using Fontix.Models;

namespace Fontix.IDAL.Data;

public interface IEventDal
{
    Task DeleteEvent(int id);
    Task<Event> GetEvent(int id);
    Task<Event> GetEventWithTickets(int id);
    Task<IEnumerable<Event>> GetAllEventsWithTickets();
    Task<IEnumerable<Event>> GetEvents();
    Task<IEnumerable<Event>> GetOrganisationEvents(int id);
    Task InsertEvent(Event myEvent);
    Task UpdateEvent(Event myEvent);
}
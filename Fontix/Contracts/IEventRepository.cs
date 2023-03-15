using Fontix.entities;

namespace Fontix.Contracts;

public interface IEventRepository
{
    public Task<IEnumerable<Event>> GetEvents();
}
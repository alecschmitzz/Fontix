using Fontix.UI.entities;

namespace Fontix.UI.Contracts;

public interface IEventRepository
{
    public Task<IEnumerable<Event>> GetEvents();
}
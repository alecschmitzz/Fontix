using Dapper;
using Fontix.UI.Context;
using Fontix.UI.Contracts;
using Fontix.UI.entities;

namespace Fontix.UI.Repository;

public class EventRepository : IEventRepository
{
    private readonly DapperContext _context;

    public EventRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetEvents()
    {
        var query = "SELECT * FROM events";

        using (var connection = _context.CreateConnection())
        {
            var events = await connection.QueryAsync<Event>(query);
            
            return events.ToList();
        }
    }
}
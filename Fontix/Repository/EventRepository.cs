using Dapper;
using Fontix.Context;
using Fontix.Contracts;
using Fontix.entities;

namespace Fontix.Repository;

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
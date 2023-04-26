using AutoMapper;
using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class EventDal : IEventDal
{
    private readonly IDbAccess _db;
    private readonly IMapper _mapper;

    public EventDal(IDbAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Models.Event>> GetEvents()
    {
        var events = await _db.LoadData<Event, dynamic>(
            storedprocedure: "alecit_fontix.sp_Events_GetAll",
            new { });

        //map data to Models.Event
        return events.Select(r => _mapper.Map<Models.Event>(r));
    }

    public async Task<Models.Event> GetEvent(int id)
    {
        var results = await _db.LoadData<Event, dynamic>(
            storedprocedure: "alecit_fontix.sp_Events_GetEvent",
            new { Ievent_id = id });

        var myEvent = results.FirstOrDefault();

        return _mapper.Map<Models.Event>(myEvent);
    }
    
    public async Task<Models.Event> GetEventWithTickets(int id)
    {
        var lookup = new Dictionary<int, Event>();
    
        var results = await _db.LoadDataWithJoin<Event, Ticket, Event, dynamic>(
            "alecit_fontix.sp_Events_GetEventWithTickets",
            new { Ievent_id = id },
            (myEvent, ticket) =>
            {
                // Check if the user already exists in the lookup
                if (!lookup.TryGetValue(myEvent.id, out Event e))
                {
                    e = myEvent;
                    e.Tickets = new List<Ticket>();
                    lookup.Add(e.id, e);
                }
    
                // Set the tickets ID using the alias
                ticket.id = ticket.alias_ticket_id;
                ticket.name = ticket.alias_ticket_name;
    
                // Add the ticket to the event's list of tickets if it doesn't already exist
                if (e.Tickets.All(r => r.id != ticket.id))
                {
                    e.Tickets.Add(ticket);
                }
    
                return e;
            },
            "id, alias_ticket_id",
            new { }
        );
    
        return _mapper.Map<Models.Event>(results);
    }

    public Task InsertEvent(Models.Event myEvent) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Events_InsertEvent",
        parameters: new
        {
            Iorganiser_id = myEvent.OrganiserId,
            Iname = myEvent.Name,
            Idescription = myEvent.Description,
        });


    public Task UpdateEvent(Models.Event myEvent) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Events_UpdateEvent",
        new
        {
            Iname = myEvent.Name,
            Idescription = myEvent.Description,
            Ievent_id = myEvent.Id
        });

    public Task DeleteEvent(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Events_DeleteEvent", new { Ievent_id = id });
}
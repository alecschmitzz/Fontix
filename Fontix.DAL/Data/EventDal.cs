using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class EventDal : IEventDal
{
    private readonly IDbAccess _db;

    public EventDal(IDbAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Models.Event>> GetEvents()
    {
        var events = await _db.LoadData<Event, dynamic>(
            storedprocedure: "alecit_fontix.sp_Events_GetAll",
            new { });

        //map data to Models.Event
        return events.Select(r => r.ConvertToModel());
    }
    
    public async Task<IEnumerable<Models.Event>> GetOrganisationEvents(int id)
    {
        var events = await _db.LoadData<Event, dynamic>(
            storedprocedure: "alecit_fontix.sp_Events_GetAllFromOrganisation",
            new { Iorganisation_id = id });

        //map data to Models.Event
        return events.Select(r => r.ConvertToModel());
    }

    public async Task<Models.Event> GetEvent(int id)
    {
        var result = await _db.LoadData<Event, dynamic>(
            storedprocedure: "alecit_fontix.sp_Events_GetEvent",
            new { Ievent_id = id });

        var myEvent = result.FirstOrDefault();

        return myEvent.ConvertToModel();
    }

    public async Task<Models.Event> GetEventWithTickets(int id)
    {
        var lookup = new Dictionary<int, Event>();

        var result = await _db.LoadDataWithJoin<Event, Ticket, Event, dynamic>(
            "alecit_fontix.sp_Events_GetEventWithTickets",
            new { Ievent_id = id },
            (myEvent, ticket) =>
            {
                // Check if the event already exists in the lookup
                if (!lookup.TryGetValue(myEvent.id, out Event e))
                {
                    e = myEvent;
                    lookup.Add(e.id, e);
                }

                // Check if ticket is null
                if (ticket != null)
                {
                    // Set the tickets ID and name using the alias
                    ticket.SetAlias();

                    // Add the ticket to the event's list of tickets if it doesn't already exist
                    if (e.Tickets.Get().All(r => r.id != ticket.id))
                    {
                        e.Tickets.Add(ticket);
                    }
                }


                return e;
            },
            "id, alias_ticket_id",
            new { }
        );
        return result.ConvertToModel();
    }

    public Task InsertEvent(Models.Event myEvent) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Events_InsertEvent",
        parameters: new
        {
            Iorganisation_id = myEvent.OrganisationId,
            Iname = myEvent.Name,
            Ivenue = myEvent.Venue,
            Idescription = myEvent.Description,
            Idatetime_view = myEvent.DateTimeView,
        });


    public Task UpdateEvent(Models.Event myEvent) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Events_UpdateEvent",
        new
        {
            Iname = myEvent.Name,
            Ivenue = myEvent.Venue,
            Idescription = myEvent.Description,
            Idatetime_view = myEvent.DateTimeView,
            Ievent_id = myEvent.Id
        });

    public Task DeleteEvent(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Events_DeleteEvent", new { Ievent_id = id });
}
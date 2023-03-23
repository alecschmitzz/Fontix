using fontix_data.DbAccess;
using fontix_data.Entities;

namespace fontix_data.Data;

public class EventData: IEventData
{
    private readonly IDbAccess _db;

    public EventData(IDbAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Event>> GetEvents() =>
        _db.LoadData<Event, dynamic>(storedprocedure: "alecit_fontix.sp_Events_GetAll", new { });

    public async Task<Event> GetEvent(int id)
    {
        var results = await _db.LoadData<Event, dynamic>(storedprocedure: "alecit_fontix.sp_Events_GetEvent",
            new { Ievent_id = id });

        return results.FirstOrDefault();
    }

    public Task InsertEvent(Event Event) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Events_InsertEvent",
        parameters: new
        {
            Iorganiser_id = Event.organiser_id,
            Iname = Event.name,
            Idescription = Event.description,
        });


    public Task UpdateEvent(Event Event) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Events_UpdateEvent",
        new
        {
            Iorganiser_id = Event.organiser_id,
            Iname = Event.name,
            Idescription = Event.description,
            Ievent_id = Event.id
        });

    public Task DeleteEvent(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Events_DeleteEvent", new { Ievent_id = id });
}
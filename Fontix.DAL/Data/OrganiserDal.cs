using AutoMapper;
using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class OrganiserDal : IOrganiserDal
{
    private readonly IDbAccess _db;

    public OrganiserDal(IDbAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Models.Organiser>> GetOrganisers()
    {
        var organisers = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetAll",
            new { });

        //map data to Models.Organiser
        return organisers.Select(r => r.ConvertToModel());
    }

    public async Task<IEnumerable<Models.Organiser>> GetOrganiserOrganisers(int id)
    {
        var organisers = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetOrganiserOrganisers",
            new { Iorganiser_id = id });

        return organisers.Select(r => r.ConvertToModel());
    }

    public async Task<Models.Organiser> GetOrganiser(int id)
    {
        var results = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetOrganiser",
            new { Iorganiser_id = id });

        var myOrganiser = results.FirstOrDefault();

        return myOrganiser.ConvertToModel();
    }

    public async Task<Models.Organiser> GetOrganiserWithReference(int id)
    {
        var lookup = new Dictionary<int, Organiser>();

        var result = await _db.LoadDataWithJoin<Organiser, Event, Organiser, dynamic>(
            "alecit_seathub.sp_Organisers_GetOrganiserWithReference",
            new { Iorganiser_id = id },
            (organiser, myEvent) =>
            {
                // Check if the organiser already exists in the lookup
                if (!lookup.TryGetValue(organiser.id, out Organiser o))
                {
                    o = organiser;
                    lookup.Add(o.id, o);
                }

                // Set the event ID using the alias
                myEvent.SetAlias();

                // Add the event to the organiser's list of events if it doesn't already exist
                if (o.Events.Get().All(r => r.id != myEvent.id))
                {
                    o.Events.Add(myEvent);
                }

                return o;
            },
            "id, alias_event_id",
            new { }
        );

        return result.ConvertToModel();
    }

    public Task InsertOrganiser(Models.Organiser organiser) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisers_InsertOrganiser",
        parameters: new
        {
            Iname = organiser.Name,
        });


    public Task UpdateOrganiser(Models.Organiser organiser) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisers_UpdateOrganiser",
        new
        {
            Iname = organiser.Name,
            Iorganiser_id = organiser.Id
        });

    public Task DeleteOrganiser(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Organisers_DeleteOrganiser", new { Iorganiser_id = id });
}
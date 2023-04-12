using AutoMapper;
using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class OrganiserDal : IOrganiserDal
{
    private readonly IDbAccess _db;
    private readonly IMapper _mapper;

    public OrganiserDal(IDbAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Models.Organiser>> GetOrganisers()
    {
        var organisers = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetAll",
            new { });

        //map data to Models.Organiser
        return organisers.Select(r => _mapper.Map<Models.Organiser>(r));
    }

    public async Task<IEnumerable<Models.Organiser>> GetOrganiserOrganisers(int id)
    {
        var organisers = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetOrganiserOrganisers",
            new { Iorganiser_id = id });

        return organisers.Select(r => _mapper.Map<Models.Organiser>(r));
    }

    public async Task<Models.Organiser> GetOrganiser(int id)
    {
        var results = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetOrganiser",
            new { Iorganiser_id = id });

        var myOrganiser = results.FirstOrDefault();

        return _mapper.Map<Models.Organiser>(myOrganiser);
    }

    public async Task<Models.Organiser> GetOrganiserWithReference(int id)
    {
        var lookup = new Dictionary<int, Organiser>();

        var results = await _db.LoadDataWithJoin<Organiser, Event, Organiser, dynamic>(
            "alecit_seathub.sp_Organisers_GetOrganiserWithReference",
            new { Iorganiser_id = id },
            (organiser, myEvent) =>
            {
                // Check if the organiser already exists in the lookup
                if (!lookup.TryGetValue(organiser.id, out Organiser o))
                {
                    o = organiser;
                    o.Events = new List<Event>();
                    lookup.Add(o.id, o);
                }

                // Set the event ID using the alias
                myEvent.id = myEvent.alias_event_id;

                // Add the event to the organiser's list of events if it doesn't already exist
                if (o.Events.All(r => r.id != myEvent.id))
                {
                    o.Events.Add(myEvent);
                }

                return o;
            },
            "id, alias_event_id",
            new { }
        );

        return _mapper.Map<Models.Organiser>(results);
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
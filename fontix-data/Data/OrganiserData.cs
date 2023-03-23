using fontix_data.DbAccess;
using fontix_data.Entities;

namespace fontix_data.Data;

public class OrganiserData : IOrganiserData
{
    private readonly IDbAccess _db;

    public OrganiserData(IDbAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Organiser>> GetOrganisers() =>
        _db.LoadData<Organiser, dynamic>(storedprocedure: "alecit_fontix.sp_Organisers_GetAll", new { });

    public async Task<Organiser> GetOrganiser(int id)
    {
        var results = await _db.LoadData<Organiser, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisers_GetOrganiser",
            new { Iorganiser_id = id });

        return results.FirstOrDefault();
    }

    public Task InsertOrganiser(Organiser organiser) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisers_InsertOrganiser",
        parameters: new
        {
            Iname = organiser.name,
        });


    public Task UpdateOrganiser(Organiser organiser) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisers_UpdateOrganiser",
        new
        {
            Iname = organiser.name,
            Iorganiser_id = organiser.id
        });

    public Task DeleteOrganiser(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Organisers_DeleteOrganiser", new { Iorganiser_id = id });
}
using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class OrganisationDal : IOrganisationDal
{
    private readonly IDbAccess _db;

    public OrganisationDal(IDbAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Models.Organisation>> GetOrganisations()
    {
        var organisations = await _db.LoadData<Organisation, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisations_GetAll",
            new { });

        //map data to Models.Organisation
        return organisations.Select(r => r.ConvertToModel());
    }

    public async Task<IEnumerable<Models.Organisation>> GetUserOrganisations(int id)
    {
        var organisations = await _db.LoadData<Organisation, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisations_GetAllFromUser",
            new { Iuser_id = id });

        //map data to Models.Organisation
        return organisations.Select(r => r.ConvertToModel());
    }

    public async Task<IEnumerable<Models.Organisation>> GetOrganisationOrganisations(int id)
    {
        var organisations = await _db.LoadData<Organisation, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisations_GetOrganisationOrganisations",
            new { Iorganisation_id = id });

        return organisations.Select(r => r.ConvertToModel());
    }

    public async Task<Models.Organisation> GetOrganisation(int id)
    {
        var results = await _db.LoadData<Organisation, dynamic>(
            storedprocedure: "alecit_fontix.sp_Organisations_GetOrganisation",
            new { Iorganisation_id = id });

        var myOrganisation = results.FirstOrDefault();

        return myOrganisation.ConvertToModel();
    }

    public async Task<Models.Organisation> GetOrganisationWithUsers(int id)
    {
        var lookup = new Dictionary<int, Organisation>();

        var result = await _db.LoadDataWithJoin<Organisation, User, Organisation, dynamic>(
            "alecit_fontix.sp_Organisations_GetOrganisationWithUsers",
            new { Iorganisation_id = id },
            (organisation, user) =>
            {
                // Check if the organisation already exists in the lookup
                if (!lookup.TryGetValue(organisation.id, out Organisation o))
                {
                    o = organisation;
                    lookup.Add(o.id, o);
                }

                // Set the event ID using the alias
                user.SetAlias();

                // Add the event to the organisation's list of events if it doesn't already exist
                if (o.Users.Get().All(r => r.id != user.id))
                {
                    o.Users.Add(user);
                }

                return o;
            },
            "id, alias_user_id",
            new { }
        );

        return result.ConvertToModel();
    }

    public Task AddMember(int organisationId, int userId) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisations_InsertMember",
        parameters: new
        {
            Iorganisation_id = organisationId,
            Iuser_id = userId
        });

    public Task RemoveMember(int organisationId, int userId) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisations_DeleteMember",
        parameters: new
        {
            Iorganisation_id = organisationId,
            Iuser_id = userId
        });

    public Task InsertOrganisation(Models.Organisation organisation, int userId) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisations_InsertOrganisation",
        parameters: new
        {
            Iname = organisation.Name,
            Iuser_id = userId
        });


    public Task UpdateOrganisation(Models.Organisation organisation) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Organisations_UpdateOrganisation",
        new
        {
            Iname = organisation.Name,
            Iorganisation_id = organisation.Id
        });

    public Task DeleteOrganisation(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Organisations_DeleteOrganisation",
            new { Iorganisation_id = id });
}
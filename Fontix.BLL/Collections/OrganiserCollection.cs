using Fontix.IBLL.Collections;
using Fontix.IDAL.Data;
using Fontix.Models;

namespace Fontix.BLL.Collections;

public class OrganisationCollection : IOrganisationCollection
{
    private readonly IOrganisationDal _data;

    public OrganisationCollection(IOrganisationDal data)
    {
        _data = data;
    }

    public async Task<List<Organisation>> GetAllOrganisations()
    {
        var organisations = await _data.GetOrganisations();
        return organisations.ToList();
    }

    public async Task<List<Organisation>> GetUserOrganisations(int id)
    {
        var organisations = await _data.GetUserOrganisations(id);
        return organisations.ToList();
    }

    public async Task<Organisation> GetOrganisation(int id)
    {
        return await _data.GetOrganisation(id);
    }

    public async Task<Organisation> GetOrganisationWithUsers(int id)
    {
        return await _data.GetOrganisationWithUsers(id);
    }

    public async Task AddMember(int organisationId, int userId)
    {
        await _data.AddMember(organisationId, userId);
    }
    
    public async Task RemoveMember(int organisationId, int userId)
    {
        await _data.RemoveMember(organisationId, userId);
    }

    public async Task InsertOrganisation(Organisation myOrganisation, int userId)
    {
        // var workspaceId = organisation.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = organisation.UserId ?? throw new InvalidInputException("userId is empty");

        await _data.InsertOrganisation(myOrganisation, userId);
    }

    public async Task UpdateOrganisation(Organisation myOrganisation)
    {
        //check for empty input
        //TODO: check input for admin stuff
        //TODO: check input if time is allowed etc.
        // var workspaceId = organisation.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = organisation.UserId ?? throw new InvalidInputException("userId is empty");


        await _data.UpdateOrganisation(myOrganisation);
    }

    public async Task DeleteOrganisation(int id)
    {
        await _data.DeleteOrganisation(id);
    }
}
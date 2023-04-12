using Fontix.IBLL.Collections;
using Fontix.IDAL.Data;
using Fontix.Models;

namespace Fontix.BLL.Collections;

public class OrganiserCollection : IOrganiserCollection
{
    private readonly IOrganiserDal _data;

    public OrganiserCollection(IOrganiserDal data)
    {
        _data = data;
    }

    public async Task<List<Organiser>> GetAllOrganisers()
    {
        var organisers = await _data.GetOrganisers();
        return organisers.ToList();
    }

    public async Task<Organiser> GetOrganiser(int id)
    {
        return await _data.GetOrganiser(id);
    }
    
    public async Task<Organiser> GetOrganiserWithReference(int id)
    {
        return await _data.GetOrganiserWithReference(id);
    }

    public async Task InsertOrganiser(Organiser myOrganiser)
    {
        // var workspaceId = organiser.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = organiser.UserId ?? throw new InvalidInputException("userId is empty");
        
        await _data.InsertOrganiser(myOrganiser);
    }

    public async Task UpdateOrganiser(Organiser myOrganiser)
    {
        //check for empty input
        //TODO: check input for admin stuff
        //TODO: check input if time is allowed etc.
        // var workspaceId = organiser.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = organiser.UserId ?? throw new InvalidInputException("userId is empty");

        
        await _data.UpdateOrganiser(myOrganiser);
    }

    public async Task DeleteOrganiser(int id)
    {
        await _data.DeleteOrganiser(id);
    }
}
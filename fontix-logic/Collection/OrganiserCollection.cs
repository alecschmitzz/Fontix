using fontix_data.Data;

namespace fontix_logic.Collection;

public class OrganiserController
{
    public async Task<List<LogicModels.Organiser>> GetAllOrganisers(IOrganiserData data)
    {
        List<fontix_data.Entities.Organiser> entitylist = new List<fontix_data.Entities.Organiser>();

        entitylist = (List<fontix_data.Entities.Organiser>)await data.GetOrganisers();

        List<LogicModels.Organiser> organisers = new List<LogicModels.Organiser>();

        foreach (fontix_data.Entities.Organiser myOrganiser in entitylist)
        {
            organisers.Add(new LogicModels.Organiser(myOrganiser));
        }

        return organisers;
    }

    public async Task<LogicModels.Organiser> GetOrganiser(IOrganiserData data, int id)
    {
        return new LogicModels.Organiser(await data.GetOrganiser(id));
    }

    public async Task InsertOrganiser(IOrganiserData data, LogicModels.Organiser myOrganiser)
    {
        fontix_data.Entities.Organiser insertOrganiser = new fontix_data.Entities.Organiser()
        {
            name = myOrganiser.name,
        };

        await data.InsertOrganiser(insertOrganiser);
    }

    public async Task UpdateOrganiser(IOrganiserData data, LogicModels.Organiser myOrganiser)
    {
        fontix_data.Entities.Organiser updateOrganiser = new fontix_data.Entities.Organiser()
        {
            id = myOrganiser.id,
            name = myOrganiser.name,
        };

        await data.UpdateOrganiser(updateOrganiser);
    }

    public async Task DeleteOrganiser(IOrganiserData data, int id)
    {
        await data.DeleteOrganiser(id);
    }
}
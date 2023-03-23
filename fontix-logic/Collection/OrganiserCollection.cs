using fontix_data.Data;

namespace fontix_logic.Collection;

public class OrganiserController
{
    private readonly IOrganiserData data;

    public async Task<List<LogicModels.Organiser>> GetAllOrganisers()
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

    public async Task<LogicModels.Organiser> GetOrganiser(int id)
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

    public async Task UpdateOrganiser(LogicModels.Organiser myOrganiser)
    {
        fontix_data.Entities.Organiser updateOrganiser = new fontix_data.Entities.Organiser()
        {
            id = myOrganiser.id,
            name = myOrganiser.name,
        };

        await data.UpdateOrganiser(updateOrganiser);
    }

    public async Task DeleteOrganiser(int id)
    {
        await data.DeleteOrganiser(id);
    }
}
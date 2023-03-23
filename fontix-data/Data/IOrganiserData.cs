using fontix_data.Entities;

namespace fontix_data.Data;

public interface IOrganiserData
{
    Task DeleteOrganiser(int id);
    Task<Organiser> GetOrganiser(int id);
    Task<IEnumerable<Organiser>> GetOrganisers();
    Task InsertOrganiser(Organiser organiser);
    Task UpdateOrganiser(Organiser organiser);
}
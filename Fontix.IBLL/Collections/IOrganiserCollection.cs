using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface IOrganiserCollection
{
    Task<List<Organiser>> GetAllOrganisers();
    Task<Organiser> GetOrganiser(int id);
    Task InsertOrganiser(Organiser organiser);
    Task UpdateOrganiser(Organiser organiser);
    Task DeleteOrganiser(int id);
}
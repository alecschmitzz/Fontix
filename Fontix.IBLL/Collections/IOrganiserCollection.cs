using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface IOrganisationCollection
{
    Task<List<Organisation>> GetAllOrganisations();
    Task<List<Organisation>> GetUserOrganisations(int id);
    Task<Organisation> GetOrganisation(int id);
    Task InsertOrganisation(Organisation organisation);
    Task UpdateOrganisation(Organisation organisation);
    Task DeleteOrganisation(int id);
}
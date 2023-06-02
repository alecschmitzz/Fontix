using Fontix.Models;

namespace Fontix.IDAL.Data;

public interface IOrganisationDal
{
    Task DeleteOrganisation(int id);
    Task<Organisation> GetOrganisation(int id);
    Task<Organisation> GetOrganisationWithReference(int id);
    Task<IEnumerable<Organisation>> GetOrganisations();
    Task<IEnumerable<Organisation>> GetUserOrganisations(int id);
    Task InsertOrganisation(Organisation organisation);
    Task UpdateOrganisation(Organisation organisation);
}
using Fontix.Models;

namespace Fontix.IDAL.Data;

public interface IOrganisationDal
{
    Task DeleteOrganisation(int id);

    Task<Organisation> GetOrganisation(int id);

    // Task<Organisation> GetOrganisationWithReference(int id);
    Task<Organisation> GetOrganisationWithUsers(int id);
    Task<IEnumerable<Organisation>> GetOrganisations();
    Task<IEnumerable<Organisation>> GetUserOrganisations(int id);
    Task AddMember(int organisationId, int userId);
    Task RemoveMember(int organisationId, int userId);
    Task InsertOrganisation(Organisation organisation, int userId);
    Task UpdateOrganisation(Organisation organisation);
}
using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface IOrganisationCollection
{
    Task<List<Organisation>> GetAllOrganisations();
    Task<List<Organisation>> GetUserOrganisations(int id);
    Task<Organisation> GetOrganisation(int id);
    Task<Organisation> GetOrganisationWithUsers(int id);
    Task AddMember(int organisationId, int userId);
    Task RemoveMember(int organisationId, int userId);
    Task InsertOrganisation(Organisation organisation, int userId);
    Task UpdateOrganisation(Organisation organisation);
    Task DeleteOrganisation(int id);
}
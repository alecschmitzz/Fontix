using Fontix.Models;

namespace Fontix.IDAL.Data;

public interface IOrganiserDal
{
    Task DeleteOrganiser(int id);
    Task<Organiser> GetOrganiser(int id);
    Task<Organiser> GetOrganiserWithReference(int id);
    Task<IEnumerable<Organiser>> GetOrganisers();
    Task InsertOrganiser(Organiser organiser);
    Task UpdateOrganiser(Organiser organiser);
}
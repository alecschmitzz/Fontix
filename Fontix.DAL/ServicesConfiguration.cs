using Fontix.DAL.Context;
using Fontix.DAL.Data;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL;

public static class ServicesConfiguration
{
    public static void AddDALServices(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();
        services.AddSingleton<IDbAccess, DbAccess.DbAccess>();
        services.AddSingleton<IEventDal, EventDal>();
        services.AddSingleton<IOrganisationDal, OrganisationDal>();
        services.AddSingleton<ITicketDal, TicketDal>();
        services.AddSingleton<IUserDal, UserDal>();
    }
}
using Fontix.BLL.Collections;
using Fontix.IBLL.Collections;

namespace Fontix.BLL;

public static class ServicesConfiguration
{
    public static void AddBLLServices(this IServiceCollection services)
    {
        services.AddSingleton<IEventCollection, EventCollection>();
        services.AddSingleton<IOrganiserCollection, OrganiserCollection>();
        services.AddSingleton<ITicketCollection, TicketCollection>();
        services.AddSingleton<IUserCollection, UserCollection>();
    }
}
using Fontix.IDAL.Data;

namespace Fontix.DAL;

public static class ApiConfig
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet(pattern: "/Event", GetEvents);
        app.MapGet(pattern: "/Event/{id}", GetEvent);
        app.MapGet(pattern: "/Event/{id}/ref", GetEventWithReference);
        app.MapPost(pattern: "/Event", InsertEvent);
        app.MapPut(pattern: "/Event", UpdateEvent);
        app.MapDelete(pattern: "/Event/{id}", DeleteEvent);
        
        app.MapGet(pattern: "/Organiser", GetOrganisers);
        app.MapGet(pattern: "/Organiser/{id}", GetOrganiser);
        app.MapGet(pattern: "/Organiser/{id}/ref", GetOrganiserWithReference);
        app.MapPost(pattern: "/Organiser", InsertOrganiser);
        app.MapPut(pattern: "/Organiser", UpdateOrganiser);
        app.MapDelete(pattern: "/Organiser/{id}", DeleteOrganiser);

        app.MapGet(pattern: "/Ticket", GetTickets);
        app.MapGet(pattern: "/Ticket/{id}", GetTicket);
        app.MapPost(pattern: "/Ticket", InsertTicket);
        app.MapPut(pattern: "/Ticket", UpdateTicket);
        app.MapDelete(pattern: "/Ticket/{id}", DeleteTicket);
        
        app.MapGet(pattern: "/Users", GetUsers);
        app.MapGet(pattern: "/Users/{id}", GetUser);
        app.MapGet(pattern: "/Users/search/email/{email}", GetUserByEmail);
        app.MapPost(pattern: "/Users", InsertUser);
        app.MapPut(pattern: "/Users", UpdateUser);
        app.MapDelete(pattern: "/Users/{id}", DeleteUser);
    }
    
    
    
    
    
    
    /* EVENTS */
    private static async Task<IResult> GetEvents(IEventDal data)
    {
        return Results.Ok(await data.GetEvents());
    }

    private static async Task<IResult> GetEvent(IEventDal data, int id)
    {
        var results = Results.Ok(await data.GetEvent(id));
        return results;
    }
    
    private static async Task<IResult> GetEventWithReference(IEventDal data, int id)
    {
        var results = Results.Ok(await data.GetEventWithReference(id));
        return results;
    }

    private static async Task<IResult> InsertEvent(IEventDal data, Models.Event myEvent)
    {
        await data.InsertEvent(myEvent);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateEvent(IEventDal data, Models.Event myEvent)
    {
        await data.UpdateEvent(myEvent);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteEvent(IEventDal data, int id)
    {
        await data.DeleteEvent(id);
        return Results.Ok();
    }
    
    
    
    
    
    
    /* ORGANISERS */
    private static async Task<IResult> GetOrganisers(IOrganiserDal data)
    {
        return Results.Ok(await data.GetOrganisers());
    }

    private static async Task<IResult> GetOrganiser(IOrganiserDal data, int id)
    {
        var results = Results.Ok(await data.GetOrganiser(id));
        return results;
    } 
    
    private static async Task<IResult> GetOrganiserWithReference(IOrganiserDal data, int id)
    {
        var results = Results.Ok(await data.GetOrganiserWithReference(id));
        return results;
    }

    private static async Task<IResult> InsertOrganiser(IOrganiserDal data, Models.Organiser organiser)
    {
        //map data
        await data.InsertOrganiser(organiser);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateOrganiser(IOrganiserDal data, Models.Organiser organiser)
    {
        //map data
        await data.UpdateOrganiser(organiser);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteOrganiser(IOrganiserDal data, int id)
    {
        await data.DeleteOrganiser(id);
        return Results.Ok();
    }
    
    
    
    
    
    
    /* TICKETS */
    private static async Task<IResult> GetTickets(ITicketDal data)
    {
        return Results.Ok(await data.GetTickets());
    }

    private static async Task<IResult> GetTicket(ITicketDal data, int id)
    {
        var results = Results.Ok(await data.GetTicket(id));
        return results;
    }

    private static async Task<IResult> InsertTicket(ITicketDal data, Models.Ticket ticket)
    {
        //map data
        await data.InsertTicket(ticket);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateTicket(ITicketDal data, Models.Ticket ticket)
    {
        //map data
        await data.UpdateTicket(ticket);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteTicket(ITicketDal data, int id)
    {
        await data.DeleteTicket(id);
        return Results.Ok();
    }
    
    
    
    
    
    
    /* USERS */
    private static async Task<IResult> GetUsers(IUserDal data)
    {
        return Results.Ok(await data.GetUsers());
    }

    private static async Task<IResult> GetUser(IUserDal data, int id)
    {
        var results = Results.Ok(await data.GetUser(id));
        return results;
    }

    private static async Task<IResult> GetUserByEmail(IUserDal data, string email)
    {
        var results = Results.Ok(await data.GetUserByEmail(email));
        return results;
    }

    private static async Task<IResult> InsertUser(IUserDal data, Models.User user)
    {
        await data.InsertUser(user);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateUser(IUserDal data, Models.User user)
    {
        await data.UpdateUser(user);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteUser(IUserDal data, int id)
    {
        await data.DeleteUser(id);
        return Results.Ok();
    }
}
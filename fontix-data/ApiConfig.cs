using fontix_data.Data;
using fontix_data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace fontix_data;

public static class ApiConfig
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet(pattern: "/Users", GetUsers);
        app.MapGet(pattern: "/Users/{id}", GetUser);
        app.MapPost(pattern: "/Users", InsertUser);
        app.MapPut(pattern: "/Users", UpdateUser);
        app.MapDelete(pattern: "/Users/{id}", DeleteUser);

        app.MapGet(pattern: "/Events", GetEvents);
        app.MapGet(pattern: "/Events/{id}", GetEvent);
        app.MapPost(pattern: "/Events", InsertEvent);
        app.MapPut(pattern: "/Events", UpdateEvent);
        app.MapDelete(pattern: "/Events/{id}", DeleteEvent);

        app.MapGet(pattern: "/Organisers", GetOrganisers);
        app.MapGet(pattern: "/Organisers/{id}", GetOrganiser);
        app.MapPost(pattern: "/Organisers", InsertOrganiser);
        app.MapPut(pattern: "/Organisers", UpdateOrganiser);
        app.MapDelete(pattern: "/Organisers/{id}", DeleteOrganiser);

        app.MapGet(pattern: "/Tickets", GetTickets);
        app.MapGet(pattern: "/Tickets/{id}", GetTicket);
        app.MapPost(pattern: "/Tickets", InsertTicket);
        app.MapPut(pattern: "/Tickets", UpdateTicket);
        app.MapDelete(pattern: "/Tickets/{id}", DeleteTicket);
    }

    //users
    private static async Task<IResult> GetUsers(IUserData data)
    {
        return Results.Ok(await data.GetUsers());
    }

    private static async Task<IResult> GetUser(IUserData data, int id)
    {
        var results = Results.Ok(await data.GetUser(id));
        return results;
    }

    private static async Task<IResult> InsertUser(IUserData data, [FromBody] User user)
    {
        await data.InsertUser(user);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateUser(IUserData data, [FromBody] User user)
    {
        await data.UpdateUser(user);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        await data.DeleteUser(id);
        return Results.Ok();
    }


    // Events
    private static async Task<IResult> GetEvents(IEventData data)
    {
        return Results.Ok(await data.GetEvents());
    }

    private static async Task<IResult> GetEvent(IEventData data, int id)
    {
        var results = Results.Ok(await data.GetEvent(id));
        return results;
    }

    private static async Task<IResult> InsertEvent(IEventData data, [FromBody] Event myEvent)
    {
        await data.InsertEvent(myEvent);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateEvent(IEventData data, [FromBody] Event myEvent)
    {
        await data.UpdateEvent(myEvent);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteEvent(IEventData data, int id)
    {
        await data.DeleteEvent(id);
        return Results.Ok();
    }


    // Organiser
    private static async Task<IResult> GetOrganisers(IOrganiserData data)
    {
        return Results.Ok(await data.GetOrganisers());
    }

    private static async Task<IResult> GetOrganiser(IOrganiserData data, int id)
    {
        var results = Results.Ok(await data.GetOrganiser(id));
        return results;
    }

    private static async Task<IResult> InsertOrganiser(IOrganiserData data, [FromBody] Organiser myOrganiser)
    {
        await data.InsertOrganiser(myOrganiser);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateOrganiser(IOrganiserData data, [FromBody] Organiser myOrganiser)
    {
        await data.UpdateOrganiser(myOrganiser);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteOrganiser(IOrganiserData data, int id)
    {
        await data.DeleteOrganiser(id);
        return Results.Ok();
    }

    // Ticket
    private static async Task<IResult> GetTickets(ITicketData data)
    {
        return Results.Ok(await data.GetTickets());
    }

    private static async Task<IResult> GetTicket(ITicketData data, int id)
    {
        var results = Results.Ok(await data.GetTicket(id));
        return results;
    }

    private static async Task<IResult> InsertTicket(ITicketData data, [FromBody] Ticket myTicket)
    {
        await data.InsertTicket(myTicket);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateTicket(ITicketData data, [FromBody] Ticket myTicket)
    {
        await data.UpdateTicket(myTicket);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteTicket(ITicketData data, int id)
    {
        await data.DeleteTicket(id);
        return Results.Ok();
    }
}
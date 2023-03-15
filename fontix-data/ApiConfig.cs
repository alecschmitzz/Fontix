using fontix_data.Data;
using fontix_data.Entities;

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
    
    private static async Task<IResult> InsertUser(IUserData data, User user)
    {
        await data.InsertUser(user);
        return Results.Ok();
    }
    
    private static async Task<IResult> UpdateUser(IUserData data, User user)
    {
        await data.UpdateUser(user);
        return Results.Ok();
    }
    
    private static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        await data.DeleteUser(id);
        return Results.Ok();
    }
}
namespace Fontix.BLL;

public static class ApiConfig
{
    public static void ConfigureApi(this WebApplication app)
    {
        // app.MapGet(pattern: "/Users", GetUsers);
        // app.MapGet(pattern: "/Users/{id}", GetUser);
        // app.MapGet(pattern: "/Users/{id}/ref", GetUserWithReference);
        // app.MapPost(pattern: "/Users", InsertUser);
        // app.MapPut(pattern: "/Users", UpdateUser);
        // app.MapDelete(pattern: "/Users/{id}", DeleteUser);
        //
        // app.MapGet(pattern: "/Workspace", GetWorkspaces);
        // app.MapGet(pattern: "/Workspace/{id}", GetWorkspace);
        // app.MapPost(pattern: "/Workspace", InsertWorkspace);
        // app.MapPut(pattern: "/Workspace", UpdateWorkspace);
        // app.MapDelete(pattern: "/Workspace/{id}", DeleteWorkspace);
        //
        // app.MapGet(pattern: "/Reservation", GetReservations);
        // app.MapGet(pattern: "/Reservation/{id}", GetReservation);
        // app.MapPost(pattern: "/Reservation", InsertReservation);
        // app.MapPut(pattern: "/Reservation", UpdateReservation);
        // app.MapDelete(pattern: "/Reservation/{id}", DeleteReservation);
    }

    //users
    // private static async Task<IResult> GetUsers(IUserData data)
    // {
    //     return Results.Ok(await data.GetUsers());
    // }
    //
    // private static async Task<IResult> GetUser(IUserData data, int id)
    // {
    //     var results = Results.Ok(await data.GetUser(id));
    //     return results;
    // }
    //
    // private static async Task<IResult> GetUserWithReference(IUserData data, int id)
    // {
    //     var results = Results.Ok(await data.GetUserWithReference(id));
    //     return results;
    // }
    //
    // private static async Task<IResult> InsertUser(IUserData data, IUser user)
    // {
    //     await data.InsertUser(user);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> UpdateUser(IUserData data, IUser user)
    // {
    //     await data.UpdateUser(user);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> DeleteUser(IUserData data, int id)
    // {
    //     await data.DeleteUser(id);
    //     return Results.Ok();
    // }
    //
    // //workspace
    //
    // private static async Task<IResult> GetWorkspaces(IWorkspaceData data)
    // {
    //     return Results.Ok(await data.GetWorkspaces());
    // }
    //
    // private static async Task<IResult> GetWorkspace(IWorkspaceData data, int id)
    // {
    //     var results = Results.Ok(await data.GetWorkspace(id));
    //     return results;
    // }
    //
    // private static async Task<IResult> InsertWorkspace(IWorkspaceData data, IWorkspace workspace)
    // {
    //     await data.InsertWorkspace(workspace);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> UpdateWorkspace(IWorkspaceData data, IWorkspace workspace)
    // {
    //     await data.UpdateWorkspace(workspace);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> DeleteWorkspace(IWorkspaceData data, int id)
    // {
    //     await data.DeleteWorkspace(id);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> GetReservations(IReservationData data)
    // {
    //     return Results.Ok(await data.GetReservations());
    // }
    //
    // private static async Task<IResult> GetReservation(IReservationData data, int id)
    // {
    //     var results = Results.Ok(await data.GetReservation(id));
    //     return results;
    // }
    //
    // private static async Task<IResult> InsertReservation(IReservationData data, IReservation reservation)
    // {
    //     await data.InsertReservation(reservation);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> UpdateReservation(IReservationData data, IReservation reservation)
    // {
    //     await data.UpdateReservation(reservation);
    //     return Results.Ok();
    // }
    //
    // private static async Task<IResult> DeleteReservation(IReservationData data, int id)
    // {
    //     await data.DeleteReservation(id);
    //     return Results.Ok();
    // }
}
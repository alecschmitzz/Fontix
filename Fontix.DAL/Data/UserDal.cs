using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class UserDal : IUserDal
{
    private readonly IDbAccess _db;

    public UserDal(IDbAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Models.User>> GetUsers()
    {
        var users = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_fontix.sp_Users_GetAll", new { });

        //map data to Models.Event
        return users.Select(r => r.ConvertToModel());
    }

    public async Task<Models.User?> GetUserByEmail(string email)
    {
        var results = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_fontix.sp_Users_GetUserByEmail",
            new { Iemail = email });

        var user = results.FirstOrDefault();
        return user == null ? null : user.ConvertToModel();
    }
    
    public async Task<Models.User?> GetUser(int id)
    {
        var results = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_fontix.sp_Users_GetUser",
            new { Iuser_id = id });

        var user = results.FirstOrDefault();
        return user == null ? null : user.ConvertToModel();
    }

    // public async Task<Models.User> GetUserWithReference(int id)
    // {
    //     var lookup = new Dictionary<int, User>();
    //
    //     var results = await _db.LoadDataWithJoin<User, Reservation, User, dynamic>(
    //         "alecit_fontix.sp_Users_GetUserWithReference",
    //         new { Iuser_id = id },
    //         (user, reservation) =>
    //         {
    //             // Check if the user already exists in the lookup
    //             if (!lookup.TryGetValue(user.id, out User u))
    //             {
    //                 u = user;
    //                 u.Reservations = new List<Reservation>();
    //                 lookup.Add(u.id, u);
    //             }
    //
    //             // Set the reservation ID using the alias
    //             reservation.id = reservation.alias_reservation_id;
    //
    //             // Add the reservation to the user's list of reservations if it doesn't already exist
    //             if (u.Reservations.All(r => r.id != reservation.id))
    //             {
    //                 u.Reservations.Add(reservation);
    //             }
    //
    //             return u;
    //         },
    //         "id, alias_reservation_id",
    //         new { }
    //     );
    //
    //     return _mapper.Map<Models.User>(results);
    // }

    public Task InsertUser(Models.User user) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_InsertUser",
        parameters: new
        {
            Iname_first = user.NameFirst,
            Iname_last = user.NameLast,
            Iuser_pwd = user.UserPwd,
            Iemail = user.Email
        });


    public Task UpdateUser(Models.User user) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_UpdateUser",
        new
        {
            Iuser_id = user.Id,
            Iname_first = user.NameFirst,
            Iname_last = user.NameLast,
            Iemail = user.Email,
        });

    public Task UpdatePassword(Models.User user) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_UpdatePassword",
        new
        {
            Iuser_id = user.Id,
            Iuser_pwd = user.UserPwd,
        });

    public Task DeleteUser(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_DeleteUser", new { Iuserid = id });
}
using AutoMapper;
using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class UserDal : IUserDal
{
    private readonly IDbAccess _db;
    private readonly IMapper _mapper;

    public UserDal(IDbAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Models.User>> GetUsers()
    {
        var users = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_seathub.sp_Users_GetAll", new { });

        return users.Select(u => _mapper.Map<Models.User>(u));
    }

    public async Task<Models.User> GetUserByEmail(string email)
    {
        var results = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_seathub.sp_Users_GetUserByEmail",
            new { UserEmail = email });

        var user = results.FirstOrDefault();
        return _mapper.Map<Models.User>(user);
    }
    
    public async Task<Models.User> GetUser(int id)
    {
        var results = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_seathub.sp_Users_GetUser",
            new { UserId = id });

        var user = results.FirstOrDefault();
        return _mapper.Map<Models.User>(user);
    }

    // public async Task<Models.User> GetUserWithReference(int id)
    // {
    //     var lookup = new Dictionary<int, User>();
    //
    //     var results = await _db.LoadDataWithJoin<User, Reservation, User, dynamic>(
    //         "alecit_seathub.sp_Users_GetUserWithReference",
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

    public Task InsertUser(Models.User user) => _db.Savedata(storedprocedure: "alecit_seathub.sp_Users_InsertUser",
        parameters: new
        {
            Iname_first = user.NameFirst,
            Iname_last = user.NameLast,
            Iuserpwd = user.UserPwd,
            Iemail = user.Email
        });


    public Task UpdateUser(Models.User user) => _db.Savedata(storedprocedure: "alecit_seathub.sp_Users_UpdateUser",
        new
        {
            UserId = user.Id,
            Iname_first = user.NameFirst,
            Iname_last = user.NameLast,
            Iemail = user.Email,
        });

    public Task UpdatePassword(Models.User user) => _db.Savedata(storedprocedure: "alecit_seathub.sp_Users_UpdatePassword",
        new
        {
            UserId = user.Id,
            Iuserpwd = user.UserPwd,
        });

    public Task DeleteUser(int id) =>
        _db.Savedata(storedprocedure: "alecit_seathub.sp_Users_DeleteUser", new { Iuserid = id });
}
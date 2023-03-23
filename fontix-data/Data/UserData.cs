using fontix_data.DbAccess;
using fontix_data.Entities;

namespace fontix_data.Data;

public class UserData : IUserData
{
    private readonly IDbAccess _db;

    public UserData(IDbAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<User>> GetUsers() =>
        _db.LoadData<User, dynamic>(storedprocedure: "alecit_fontix.sp_Users_GetAll", new { });

    public async Task<User> GetUser(int id)
    {
        var results = await _db.LoadData<User, dynamic>(storedprocedure: "alecit_fontix.sp_Users_GetUser",
            new { Iuser_id = id });

        return results.FirstOrDefault();
    }

    public Task InsertUser(User user) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_InsertUser",
        parameters: new
        {
            Iname_first = user.name_first,
            Iname_last = user.name_last,
            Iuserpwd = user.userpwd,
            Iemail = user.email
        });


    public Task UpdateUser(User user) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_UpdateUser",
        new
        {
            Iname_first = user.name_first,
            Iname_last = user.name_last,
            Iemail = user.email,
            Iuser_id = user.id
        });


    public Task UpdateUserPwd(User user) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_UpdateUserPwd",
        new
        {
            Iuserpwd = user.userpwd,
            Iuser_id = user.id
        });

    public Task DeleteUser(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Users_DeleteUser", new { Iuser_id = id });
}
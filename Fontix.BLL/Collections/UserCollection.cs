using Fontix.IBLL.Collections;
using Fontix.IDAL.Data;
using Fontix.Models;
using BCrypt.Net;

namespace Fontix.BLL.Collections;

public class UserCollection : IUserCollection
{
    private readonly IUserDal _data;

    public UserCollection(IUserDal data)
    {
        _data = data;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _data.GetUsers();
        return users.ToList();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _data.GetUser(id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _data.GetUserByEmail(email);
    }

    public async Task<User?> AuthenticateAndGetUser(string email, string password)
    {
        var user = await _data.GetUserByEmail(email);

        return BCrypt.Net.BCrypt.Verify(password, user.UserPwd) ? user : null;
    }

    public async Task InsertUser(User user)
    {
        var password = BCrypt.Net.BCrypt.HashPassword(user.UserPwd);
        var myUser = new User(null, user.NameFirst, user.NameLast, password, user.Email);
        await _data.InsertUser(myUser);
    }

    public async Task UpdateUser(User user)
    {
        await _data.UpdateUser(user);
    }

    public async Task UpdatePassword(User user)
    {
        await _data.UpdatePassword(user);
    }

    public async Task DeleteUser(int id)
    {
        await _data.DeleteUser(id);
    }
}
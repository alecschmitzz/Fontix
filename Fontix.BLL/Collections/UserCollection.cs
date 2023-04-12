using Fontix.IBLL.Collections;
using Fontix.IDAL.Data;
using Fontix.Models;

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

    public async Task<User> GetUser(int id)
    {
        return await _data.GetUser(id);
    }

    public async Task InsertUser(User user)
    {
        await _data.InsertUser(user);
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
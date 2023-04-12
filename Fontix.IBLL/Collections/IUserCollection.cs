using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface IUserCollection
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUser(int id);
    Task InsertUser(User user);
    Task UpdateUser(User user);
    Task UpdatePassword(User user);
    Task DeleteUser(int id);
}
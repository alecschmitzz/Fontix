using Fontix.Models;

namespace Fontix.IDAL.Data;

public interface IUserDal
{
    Task DeleteUser(int id);
    Task<User?> GetUser(int id);
    Task<User?> GetUserByEmail(string email);
    // Task<User> GetUserWithReference(int id);
    Task<IEnumerable<User>> GetUsers();
    Task InsertUser(User user);
    Task UpdateUser(User user);
    Task UpdatePassword(User user);
}
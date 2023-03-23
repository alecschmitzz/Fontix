using fontix_data.Entities;

namespace fontix_data.Data;

public interface IUserData
{
    Task DeleteUser(int id);
    Task<User> GetUser(int id);
    Task<IEnumerable<User>> GetUsers();
    Task InsertUser(User user);
    Task UpdateUser(User user);
    Task UpdateUserPwd(User user);
}
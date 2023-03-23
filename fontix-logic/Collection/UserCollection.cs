using fontix_data.Data;

namespace fontix_logic.Collection;

public class UserController
{
    public async Task<List<LogicModels.User>> GetAllUsers(IUserData data)
    {
        List<fontix_data.Entities.User> entitylist = new List<fontix_data.Entities.User>();

        entitylist = (List<fontix_data.Entities.User>)await data.GetUsers();

        List<LogicModels.User> users = new List<LogicModels.User>();

        foreach (fontix_data.Entities.User user in entitylist)
        {
            users.Add(new LogicModels.User(user));
        }

        return users;
    }

    public async Task<LogicModels.User> GetUser(IUserData data, int id)
    {
        return new LogicModels.User(await data.GetUser(id));
    }

    public async Task InsertUser(IUserData data, LogicModels.User user)
    {
        fontix_data.Entities.User insertUser = new fontix_data.Entities.User()
        {
            name_first = user.name_first,
            name_last = user.name_last,
            userpwd = user.userpwd,
            email = user.email
        };

        await data.InsertUser(insertUser);
    }

    public async Task UpdateUser(IUserData data, LogicModels.User user)
    {
        fontix_data.Entities.User updateUser = new fontix_data.Entities.User()
        {
            id = user.id,
            name_first = user.name_first,
            name_last = user.name_last,
            email = user.email
        };

        await data.UpdateUser(updateUser);
    }

    public async Task UpdatePassword(IUserData data, LogicModels.User user)
    {
        fontix_data.Entities.User updateUser = new fontix_data.Entities.User()
        {
            id = user.id,
            userpwd = user.userpwd,
        };

        await data.UpdateUserPwd(updateUser);
    }

    public async Task DeleteUser(IUserData data, int id)
    {
        await data.DeleteUser(id);
    }
}
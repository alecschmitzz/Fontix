using fontix_data.Data;
using fontix_logic.Collection;

namespace fontix_logic.LogicModels;

public class User
{
    private readonly IUserData _userdata;


    public int? id { get; set; }
    public string name_first { get; set; }
    public string name_last { get; set; }
    public string userpwd { get; set; }
    public string email { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }


    /// <summary>
    /// CTOR for DTO
    /// </summary>
    /// <param name="DTOUser"></param>
    public User(fontix_data.Entities.User DTOUser)
    {
        id = DTOUser.id;
        name_first = DTOUser.name_first;
        name_last = DTOUser.name_last;
        userpwd = DTOUser.userpwd;
        email = DTOUser.email;
    }

    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nameFirst"></param>
    /// <param name="nameLast"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="createdAt"></param>
    /// <param name="updatedAt"></param>
    public User(int id,
        string nameFirst,
        string nameLast,
        string email,
        string password,
        DateTime createdAt,
        DateTime updatedAt)
    {
        this.id = id;
        name_first = nameFirst;
        name_last = nameLast;
        userpwd = password;
        this.email = email;
        created_at = createdAt;
        updated_at = updatedAt;
    }


    public async Task UpdateUser()
    {
        UserController userController = new();
        await userController.UpdateUser(_userdata, this);
    }

    public async Task UpdatePassword()
    {
        UserController userController = new();
        await userController.UpdatePassword(_userdata, this);
    }
}
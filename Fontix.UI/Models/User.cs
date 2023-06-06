using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class User
{
    public int? Id { get; private set; }
    public string NameFirst { get; private set; }
    public string NameLast { get; private set; }
    public string UserPwd { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public User()
    {
    }

    public User(RegisterBindingModel model)
    {
        NameFirst = model.NameFirst;
        NameLast = model.NameLast;
        UserPwd = model.Password;
        Email = model.Email;
    }
    
    public User(int id, string nameFirst, string nameLast, string userPwd, string email)
    {
        Id = id;
        NameFirst = nameFirst;
        NameLast = nameLast;
        UserPwd = userPwd;
        Email = email;
    }

    public User(Fontix.Models.User logicUser)
    {
        Id = logicUser.Id;
        NameFirst = logicUser.NameFirst;
        NameLast = logicUser.NameLast;
        UserPwd = logicUser.UserPwd;
        Email = logicUser.Email;
    }

    public Fontix.Models.User ConvertToModel()
    {
        return new Fontix.Models.User(Id, NameFirst, NameLast, UserPwd, Email);
    }
}
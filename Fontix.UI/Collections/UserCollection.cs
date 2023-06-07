using Fontix.UI.Models;

namespace Fontix.UI.Collections;

public class UserCollection
{
    private readonly List<User> _users = new List<User>();

    public UserCollection()
    {
        _users = new List<User>();
    }

    public UserCollection(List<User> users)
    {
        _users = users;
    }

    public UserCollection(List<Fontix.Models.User> users)
    {
        foreach (var user in users)
        {
            Add(new User((int)user.Id, user.NameFirst, user.NameLast, user.UserPwd, user.Email));
        }
    }

    public List<User> Get()
    {
        return _users;
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}
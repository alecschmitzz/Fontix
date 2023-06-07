using Fontix.DAL.Entities;

namespace Fontix.DAL.Collections;

public class UserCollection
{
    private readonly List<User> _users;

    public UserCollection()
    {
        _users = new List<User>();
    }

    public UserCollection(List<User> users)
    {
        _users = users;
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
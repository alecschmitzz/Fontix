namespace Fontix.Models;

public class User
{
    public int Id { get; private set; }
    public string NameFirst { get; private set; }
    public string NameLast { get; private set; }
    public string UserPwd { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public User()
    {
    }

    public User(int id, string nameFirst, string nameLast, string userPwd, string email)
    {
        Id = id;
        NameFirst = nameFirst;
        NameLast = nameLast;
        UserPwd = userPwd;
        Email = email;
    }
}
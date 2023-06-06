namespace Fontix.DAL.Entities;

public class User
{
    public int id { get; private set; }
    public string name_first { get; private set; }
    public string name_last { get; private set; }
    public string user_pwd { get; private set; }
    public string email { get; private set; }
    public DateTime created_at { get; private set; }
    public DateTime updated_at { get; private set; }


    public User()
    {
    }

    public User(int id, string nameFirst, string nameLast, string userPwd, string email)
    {
        this.id = id;
        this.name_first = nameFirst;
        this.name_last = nameLast;
        this.user_pwd = userPwd;
        this.email = email;
    }

    public Fontix.Models.User ConvertToModel()
    {
        return new Models.User(id, name_first, name_last, user_pwd, email);
    }
}
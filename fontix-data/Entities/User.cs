namespace fontix_data.Entities;

public class User
{
    public int? id { get; set; }
    public string name_first { get; set; }
    public string name_last { get; set; }
    public string userpwd { get; set; }
    public string email { get; set; }
    public string? created_at { get; set; }
    public string? updated_at { get; set; }

    public User(string name_first, string name_last, string userpwd, string email)
    {
        this.name_first = name_first;
        this.name_last = name_last;
        this.userpwd = userpwd;
        this.email = email;
    }

    public User(int id, string name_first, string name_last, string userpwd, string email, DateTime created_at,
        DateTime updated_at)
    {
        this.id = id;
        this.name_first = name_first;
        this.name_last = name_last;
        this.userpwd = userpwd;
        this.email = email;
        this.created_at = created_at.ToString();
        this.updated_at = updated_at.ToString();
    }

    public User()
    {
    }
}
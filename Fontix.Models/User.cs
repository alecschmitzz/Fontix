namespace Fontix.Models;

public class User
{
    public int Id { get; set; }
    public string NameFirst { get; set; }
    public string NameLast { get; set; }
    public string UserPwd { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
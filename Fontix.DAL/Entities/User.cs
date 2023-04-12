namespace Fontix.DAL.Entities;

public class User
{
    public int id { get; set; }
    public string name_first { get; set; }
    public string name_last { get; set; }
    public string userpwd { get; set; }
    public string email { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
    
    
}
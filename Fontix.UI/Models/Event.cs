namespace Fontix.UI.Models;

public class Event
{
    public int Id { get; set; }
    public int OrganiserId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}
namespace fontix_data.Entities;

public class Ticket
{
    public int id { get; set; }
    public string name { get; set; }
    public int event_id { get; set; }
    public decimal price { get; set; }
    public DateTime datetime_start { get; set; }
    public DateTime datetime_end { get; set; }
    public DateTime datetime_view { get; set; }
    public int amount { get; set; }
}
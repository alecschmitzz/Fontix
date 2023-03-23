namespace fontix_logic.LogicModels;

public class Event
{
    public int id { get; set; }
    public int organiser_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public Event(fontix_data.Entities.Event DTOevent)
    {
        id = DTOevent.id;
        organiser_id = DTOevent.organiser_id;
        name = DTOevent.name;
        description = DTOevent.description;
    }

    public Event(
        int id,
        int organiserId,
        string name,
        string description)
    {
        this.id = id;
        organiser_id = organiserId;
        this.name = name;
        this.description = description;
    }
}
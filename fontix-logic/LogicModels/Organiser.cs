namespace fontix_logic.LogicModels;

public class Organiser
{
    public int id { get; set; }
    public string name { get; set; }

    public Organiser(fontix_data.Entities.Organiser DTOOrganiser)
    {
        id = DTOOrganiser.id;
        name = DTOOrganiser.name;
    }

    public Organiser(
        int id,
        string name)
    {
        this.id = id;
        this.name = name;
    }
}
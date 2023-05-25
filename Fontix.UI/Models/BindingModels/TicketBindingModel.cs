namespace Fontix.UI.Models.BindingModels;

public class TicketBindingModel
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
    public DateTime DateTimeView { get; set; }
    public int Amount { get; set; }
}
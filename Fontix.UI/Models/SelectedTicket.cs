using Fontix.UI.Models.BindingModels;
using Newtonsoft.Json;

namespace Fontix.UI.Models;

public class SelectedTicket
{
    public int Id { get; private set; }
    public int Quantity { get; private set; }

    [JsonConstructor]
    public SelectedTicket(int id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }

    public SelectedTicket(SelectedTicketBindingModel bindingModel)
    {
        Id = bindingModel.Id;
        Quantity = bindingModel.Quantity;
    }
}
using Fontix.UI.Models.BindingModels;

namespace Fontix.UI.Models;

public class Ticket
{
    public int Id { get; private set; }
    public int EventId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime DateTimeStart { get; private set; }
    public DateTime DateTimeEnd { get; private set; }
    public DateTime DateTimeView { get; private set; }
    public int Amount { get; private set; }


    public Ticket(int id, int eventId, string name, decimal price, DateTime dateTimeStart, DateTime dateTimeEnd,
        DateTime dateTimeView, int amount)
    {
        Id = id;
        EventId = eventId;
        Name = name;
        Price = price;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        DateTimeView = dateTimeView;
        Amount = amount;
    }

    public Ticket(Fontix.Models.Ticket ticket)
    {
        Id = ticket.Id;
        EventId = ticket.EventId;
        Name = ticket.Name;
        Price = ticket.Price;
        DateTimeStart = ticket.DatetimeStart;
        DateTimeEnd = ticket.DatetimeEnd;
        DateTimeView = ticket.DatetimeView;
        Amount = ticket.Amount;
    }

    public Ticket(TicketBindingModel bindingModel)
    {
        Id = bindingModel.Id;
        EventId = bindingModel.EventId;
        Name = bindingModel.Name;
        Price = bindingModel.Price;
        DateTimeStart = bindingModel.DateTimeStart;
        DateTimeEnd = bindingModel.DateTimeEnd;
        DateTimeView = bindingModel.DateTimeView;
        Amount = bindingModel.Amount;
    }

    public Fontix.Models.Ticket ConvertToModel()
    {
        return new Fontix.Models.Ticket(Id, EventId, Name, Price, DateTimeStart, DateTimeEnd, DateTimeView, Amount);
    }
}
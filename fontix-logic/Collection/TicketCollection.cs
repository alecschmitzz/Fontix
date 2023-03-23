using fontix_data.Data;

namespace fontix_logic.Collection;

public class TicketController
{
    private readonly ITicketData data;

    public async Task<List<LogicModels.Ticket>> GetAllTickets()
    {
        List<fontix_data.Entities.Ticket> entitylist = new List<fontix_data.Entities.Ticket>();

        entitylist = (List<fontix_data.Entities.Ticket>)await data.GetTickets();

        List<LogicModels.Ticket> tickets = new List<LogicModels.Ticket>();

        foreach (fontix_data.Entities.Ticket ticket in entitylist)
        {
            tickets.Add(new LogicModels.Ticket(ticket));
        }

        return tickets;
    }

    public async Task<LogicModels.Ticket> GetTicket(int id)
    {
        return new LogicModels.Ticket(await data.GetTicket(id));
    }

    public async Task InsertTicket(LogicModels.Ticket ticket)
    {
        fontix_data.Entities.Ticket insertTicket = new fontix_data.Entities.Ticket()
        {
            name = ticket.name,
            event_id = ticket.event_id,
            price = ticket.price,
            datetime_start = ticket.datetime_start,
            datetime_end = ticket.datetime_end,
            datetime_view = ticket.datetime_view,
            amount = ticket.amount,
        };

        await data.InsertTicket(insertTicket);
    }

    public async Task UpdateTicket(LogicModels.Ticket ticket)
    {
        fontix_data.Entities.Ticket updateTicket = new fontix_data.Entities.Ticket()
        {
            id = ticket.id,
            name = ticket.name,
            event_id = ticket.event_id,
            price = ticket.price,
            datetime_start = ticket.datetime_start,
            datetime_end = ticket.datetime_end,
            datetime_view = ticket.datetime_view,
            amount = ticket.amount,
        };

        await data.UpdateTicket(updateTicket);
    }

    public async Task DeleteTicket(int id)
    {
        await data.DeleteTicket(id);
    }
}
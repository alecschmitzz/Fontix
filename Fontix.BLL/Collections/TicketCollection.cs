using Fontix.IBLL.Collections;
using Fontix.IDAL.Data;
using Fontix.Models;

namespace Fontix.BLL.Collections;

public class TicketCollection : ITicketCollection
{
    private readonly ITicketDal _data;

    public TicketCollection(ITicketDal data)
    {
        _data = data;
    }

    public async Task<List<Ticket>> GetAllTickets()
    {
        var tickets = await _data.GetTickets();
        return tickets.ToList();
    }

    public async Task<Ticket> GetTicket(int id)
    {
        return await _data.GetTicket(id);
    }

    public async Task InsertTicket(Ticket myTicket)
    {
        // var workspaceId = ticket.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = ticket.UserId ?? throw new InvalidInputException("userId is empty");
        
        await _data.InsertTicket(myTicket);
    }

    public async Task UpdateTicket(Ticket myTicket)
    {
        //check for empty input
        //TODO: check input for admin stuff
        //TODO: check input if time is allowed etc.
        // var workspaceId = ticket.WorkspaceId ?? throw new InvalidInputException("workspaceId is empty");
        // var userId = ticket.UserId ?? throw new InvalidInputException("userId is empty");

        
        await _data.UpdateTicket(myTicket);
    }

    public async Task DeleteTicket(int id)
    {
        await _data.DeleteTicket(id);
    }
}
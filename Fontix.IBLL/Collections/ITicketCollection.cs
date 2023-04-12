using Fontix.Models;

namespace Fontix.IBLL.Collections;

public interface ITicketCollection
{
    Task<List<Ticket>> GetAllTickets();
    Task<Ticket> GetTicket(int id);
    Task InsertTicket(Ticket ticket);
    Task UpdateTicket(Ticket ticket);
    Task DeleteTicket(int id);
}
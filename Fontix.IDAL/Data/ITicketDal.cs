using Fontix.Models;

namespace Fontix.IDAL.Data;

public interface ITicketDal
{
    Task DeleteTicket(int id);
    Task<Ticket> GetTicket(int id);
    Task<IEnumerable<Ticket>> GetTickets();
    Task<IEnumerable<Ticket>> GetUserTickets(int id);
    Task InsertTicket(Ticket ticket);
    Task UpdateTicket(Ticket ticket);
}
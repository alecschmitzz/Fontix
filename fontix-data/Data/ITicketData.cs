using fontix_data.Entities;

namespace fontix_data.Data;

public interface ITicketData
{
    Task DeleteTicket(int id);
    Task<Ticket> GetTicket(int id);
    Task<IEnumerable<Ticket>> GetTickets();
    Task InsertTicket(Ticket ticket);
    Task UpdateTicket(Ticket ticket);
}
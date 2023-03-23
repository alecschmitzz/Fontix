using fontix_data.DbAccess;
using fontix_data.Entities;

namespace fontix_data.Data;

public class TicketData: ITicketData
{
    private readonly IDbAccess _db;

    public TicketData(IDbAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Ticket>> GetTickets() =>
        _db.LoadData<Ticket, dynamic>(storedprocedure: "alecit_fontix.sp_Tickets_GetAll", new { });

    public async Task<Ticket> GetTicket(int id)
    {
        var results = await _db.LoadData<Ticket, dynamic>(storedprocedure: "alecit_fontix.sp_Tickets_GetTicket",
            new { Iticket_id = id });

        return results.FirstOrDefault();
    }

    public Task InsertTicket(Ticket Ticket) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Tickets_InsertTicket",
        parameters: new
        {
            Iname = Ticket.name,
            Ievent_id = Ticket.event_id,
            Idatetime_start = Ticket.datetime_start,
            Idatetime_end = Ticket.datetime_end,
            Idatetime_view = Ticket.datetime_view,
            Iamount = Ticket.amount
        });


    public Task UpdateTicket(Ticket Ticket) => _db.Savedata(storedprocedure: "alecit_fontix.sp_Tickets_UpdateTicket",
        new
        {
            Iname = Ticket.name,
            Ievent_id = Ticket.event_id,
            Idatetime_start = Ticket.datetime_start,
            Idatetime_end = Ticket.datetime_end,
            Idatetime_view = Ticket.datetime_view,
            Iamount = Ticket.amount,
            Iticket_id = Ticket.id
        });

    public Task DeleteTicket(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Tickets_DeleteTicket", new { Iticket_id = id });
}
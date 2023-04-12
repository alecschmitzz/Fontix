using AutoMapper;
using Fontix.DAL.Entities;
using Fontix.IDAL.Data;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.Data;

public class TicketDal : ITicketDal
{
    private readonly IDbAccess _db;
    private readonly IMapper _mapper;

    public TicketDal(IDbAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Models.Ticket>> GetTickets()
    {
        var tickets = await _db.LoadData<Ticket, dynamic>(
            storedprocedure: "alecit_fontix.sp_Tickets_GetAll",
            new { });

        //map data to Models.Ticket
        return tickets.Select(r => _mapper.Map<Models.Ticket>(r));
    }

    public async Task<IEnumerable<Models.Ticket>> GetUserTickets(int id)
    {
        var tickets = await _db.LoadData<Ticket, dynamic>(
            storedprocedure: "alecit_fontix.sp_Tickets_GetUserTickets",
            new { Iuser_id = id });

        return tickets.Select(r => _mapper.Map<Models.Ticket>(r));
    }

    public async Task<Models.Ticket> GetTicket(int id)
    {
        var results = await _db.LoadData<Ticket, dynamic>(
            storedprocedure: "alecit_fontix.sp_Tickets_GetTicket",
            new { Iticket_id = id });

        var myTicket = results.FirstOrDefault();

        return _mapper.Map<Models.Ticket>(myTicket);
    }

    public Task InsertTicket(Models.Ticket ticket) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Tickets_InsertTicket",
        parameters: new
        {
            Iname = ticket.Name,
            Ievent_id = ticket.EventId,
            Idatetime_start = ticket.DatetimeStart,
            Idatetime_end = ticket.DatetimeView,
            Idatetime_view = ticket.DatetimeView,
            Iamount = ticket.Amount
        });


    public Task UpdateTicket(Models.Ticket ticket) => _db.Savedata(
        storedprocedure: "alecit_fontix.sp_Tickets_UpdateTicket",
        new
        {
            Iname = ticket.Name,
            Ievent_id = ticket.EventId,
            Idatetime_start = ticket.DatetimeStart,
            Idatetime_end = ticket.DatetimeEnd,
            Idatetime_view = ticket.DatetimeView,
            Iamount = ticket.Amount,
            Iticket_id = ticket.Id
        });

    public Task DeleteTicket(int id) =>
        _db.Savedata(storedprocedure: "alecit_fontix.sp_Tickets_DeleteTicket", new { Iticket_id = id });
}
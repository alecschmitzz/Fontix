using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class TicketController : Controller
{
    private readonly ITicketCollection _ticketCollection;
    private readonly IMapper _mapper;
    private readonly ISessionAccess _sessionAccess;


    public TicketController(ITicketCollection ticketCollection, IMapper mapper, ISessionAccess sessionAccess)
    {
        _ticketCollection = ticketCollection;
        _mapper = mapper;
        _sessionAccess = sessionAccess;
    }

    //GET TICKETS
    public async Task<IActionResult> ManageTickets(int eventId)
    {
        var tickets = await _ticketCollection.GetAllTickets();

        var myObj = new
        {
            tickets,
            eventId
        };

        return View(myObj);
    }
    
    //GET ticket
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var logicTicket = await _ticketCollection.GetTicket(id.Value);

        if (logicTicket == null)
        {
            return NotFound();
        }

        var uiTicket = _mapper.Map<Fontix.UI.Models.Ticket>(logicTicket);

        return View(uiTicket);
    }

    
    //POST TICKET
    [HttpPost]
    public async Task<IActionResult> Create(Models.Ticket uiTicket)
    {
        if (uiTicket == null)
        {
            throw new Exception("empty values");
        }

        // check if user is part of companyId
        // int userId = _sessionAccess.GetUserId();
        //
        // if (userId == 0)
        // {
        //     return RedirectToAction("Login", "User");
        // }
        //
        // uiTicket.OrganiserId = userId;

        Fontix.Models.Ticket logicTicket = _mapper.Map<Fontix.Models.Ticket>(uiTicket);
        try
        {
            await _ticketCollection.InsertTicket(logicTicket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("ManageTickets");
    }

    //EDIT ticket
    [HttpPost]
    public async Task<IActionResult> Edit(Fontix.UI.Models.Ticket uiTicket)
    {
        if (uiTicket == null)
        {
            throw new Exception("empty values");
        }

        Fontix.Models.Ticket logicTicket = _mapper.Map<Fontix.Models.Ticket>(uiTicket);
        try
        {
            await _ticketCollection.UpdateTicket(logicTicket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("ManageTickets");
    }

    //DELETE ticket
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
        {
            throw new Exception("empty values");
        }


        try
        {
            await _ticketCollection.DeleteTicket(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("ManageTickets");
    }
}
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class TicketsController : Controller
{
    private readonly ITicketCollection _ticketCollection;
    private readonly ISessionAccess _sessionAccess;


    public TicketsController(ITicketCollection ticketCollection, ISessionAccess sessionAccess)
    {
        _ticketCollection = ticketCollection;
        _sessionAccess = sessionAccess;
    }

    //CREATE TICKET
    [HttpPost]
    public async Task<IActionResult> Create(TicketBindingModel bindingModel)
    {
        var uiTicket = new Ticket(bindingModel);

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

        try
        {
            await _ticketCollection.InsertTicket(uiTicket.ConvertToModel());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("Details", "Events", new { id = uiTicket.EventId });
    }

    //READ TICKETS
    public async Task<IActionResult> ManageTickets(int eventId)
    {
        List<Fontix.Models.Ticket> logicTickets = await _ticketCollection.GetAllTickets();

        var uiTicketCollection = new TicketCollection(logicTickets);


        var tuple = (EventId: eventId, TicketCollection: uiTicketCollection);

        return View(tuple);
    }

    //READ TICKET
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

        var uiTicket = new Ticket(logicTicket);

        return View(uiTicket);
    }

    //UPDATE TICKET
    [HttpPost]
    public async Task<IActionResult> Edit(TicketBindingModel bindingModel)
    {
        var uiTicket = new Ticket(bindingModel);
        if (uiTicket == null)
        {
            throw new Exception("empty values");
        }

        var logicTicket = uiTicket.ConvertToModel();
        try
        {
            await _ticketCollection.UpdateTicket(logicTicket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("Details", "Events", new { id = uiTicket.EventId });
    }

    //DELETE ticket
    [HttpPost]
    public async Task<IActionResult> Delete(int id, int eventId)
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

        return RedirectToAction("Details", "Events", new { id = eventId });
    }
}
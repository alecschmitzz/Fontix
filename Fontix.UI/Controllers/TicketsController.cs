using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fontix.UI.Controllers;

public class TicketsController : Controller
{
    private readonly ITicketCollection _ticketCollection;
    private readonly IEventCollection _eventCollection;
    private readonly IOrganisationCollection _organisationCollection;
    private readonly ISessionAccess _sessionAccess;


    public TicketsController(ITicketCollection ticketCollection, IEventCollection eventCollection,
        IOrganisationCollection organisationCollection,
        ISessionAccess sessionAccess)
    {
        _ticketCollection = ticketCollection;
        _eventCollection = eventCollection;
        _organisationCollection = organisationCollection;
        _sessionAccess = sessionAccess;
    }

    //CREATE TICKET
    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketBindingModel bindingModel)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;
        ViewBag.LoggedInUserId = loggedInUserId;

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = string.Join("<br>", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            // Handle validation errors
            return RedirectToAction("Details", "EventsAdmin", new { id = bindingModel.EventId });
        }

        if (bindingModel.EventId == 0)
        {
            TempData["ErrorMessage"] = "No event set";
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }

        var logicEvent = await _eventCollection.GetEvent(bindingModel.EventId);

        var logicOrganisation = await _organisationCollection.GetOrganisationWithUsers(logicEvent.OrganisationId);

        Boolean userInOrganisation = logicOrganisation.Users.Any(user => user.Id == loggedInUserId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }


        var uiTicket = new Ticket(bindingModel);

        try
        {
            await _ticketCollection.InsertTicket(uiTicket.ConvertToModel());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("Details", "EventsAdmin", new { id = bindingModel.EventId });
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
    public async Task<IActionResult> Edit(EditTicketBindingModel bindingModel)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;
        ViewBag.LoggedInUserId = loggedInUserId;

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = string.Join("<br>", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            // Handle validation errors
            return RedirectToAction("Details", "EventsAdmin", new { id = bindingModel.EventId });
        }

        if (bindingModel.EventId == 0)
        {
            TempData["ErrorMessage"] = "No event set";
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }

        var logicEvent = await _eventCollection.GetEvent(bindingModel.EventId);

        var logicOrganisation = await _organisationCollection.GetOrganisationWithUsers(logicEvent.OrganisationId);

        Boolean userInOrganisation = logicOrganisation.Users.Any(user => user.Id == loggedInUserId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }

        var uiTicket = new Ticket(bindingModel);

        var logicTicket = uiTicket.ConvertToModel();
        try
        {
            await _ticketCollection.UpdateTicket(logicTicket);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Details", "EventsAdmin", new { id = bindingModel.EventId });
        }


        return RedirectToAction("Details", "EventsAdmin", new { id = uiTicket.EventId });
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

        return RedirectToAction("Details", "EventsAdmin", new { id = eventId });
    }
}
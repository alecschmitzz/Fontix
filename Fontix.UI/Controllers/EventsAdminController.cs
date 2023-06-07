using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class EventsAdminController : Controller
{
    private readonly IEventCollection _eventCollection;
    private readonly IOrganisationCollection _organisationCollection;
    private readonly ISessionAccess _sessionAccess;


    public EventsAdminController(IEventCollection eventCollection, IOrganisationCollection organisationCollection,
        ISessionAccess sessionAccess)
    {
        _eventCollection = eventCollection;
        _organisationCollection = organisationCollection;
        _sessionAccess = sessionAccess;
    }

    //CREATE EVENT
    [HttpPost]
    public async Task<IActionResult> Create(CreateEventBindingModel bindingModel)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;

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
            return RedirectToAction("Manage", new { id = bindingModel.OrganisationId });
        }

        if (bindingModel.OrganisationId == 0)
        {
            TempData["ErrorMessage"] = "No organisation set";
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }
        
        var logicOrganisation = await _organisationCollection.GetOrganisationWithUsers(bindingModel.OrganisationId);
        Boolean userInOrganisation = logicOrganisation.Users.Any(user => user.Id == loggedInUserId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }
        
        
        
        var uiEvent = new Event(bindingModel);
        

        var logicEvent = uiEvent.ConvertToModel();
        try
        {
            await _eventCollection.InsertEvent(logicEvent);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Manage");
        }


        return RedirectToAction("Manage");
    }

    //READ EVENTS (id = organisationId)
    public async Task<IActionResult> Manage(int? id)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;
        ViewBag.LoggedInUserId = loggedInUserId;

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        //DETERMINE THE ORGANISATION ID IF ID IS NULL
        if (id == null)
        {
            // GET THE FIRST ORGANISATION OF THE USER

            var userOrganisations = await _organisationCollection.GetUserOrganisations(loggedInUserId);
            if (userOrganisations.Count > 0)
            {
                id = userOrganisations[0].Id;
            }
            // If the user has no organisations, set id to null
            else
            {
                id = null;
            }
        }

        //GET THE ORGANISATION INCLUDING EVENTS BELONGING TO THE ORGANISATION
        List<Event> uiEvents = new List<Event>();
        if (id != null)
        {
            var logicEvents = await _eventCollection.GetOrganisationEvents((int)id);
            uiEvents = logicEvents.Select(logicEvent => new Event(logicEvent)).ToList();
        }

        //GET ORGANISATIONS BELONGING TO USER FOR DROPDOWN
        var logicOrganisations = await _organisationCollection.GetUserOrganisations(loggedInUserId);
        var uiOrganisations = logicOrganisations.Select(logicOrganisation => new Organisation(logicOrganisation))
            .ToList();

        var tupleModel = new Tuple<List<Event>, List<Organisation>, int?>(uiEvents, uiOrganisations, id ?? null);

        return View(tupleModel);
    }


    //READ EVENT
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;

        var logicEvent = await _eventCollection.GetEventWithTickets(id);

        var uiEvent = new Event(logicEvent);

        return View(uiEvent);
    }

    //UPDATE event
    [HttpPost]
    public async Task<IActionResult> Edit(EditEventBindingModel bindingModel)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;

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
            return RedirectToAction("Details", new { id = bindingModel.Id });
        }

        if (bindingModel.Id == 0)
        {
            TempData["ErrorMessage"] = "No event set";
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }

        var logicEvent = await _eventCollection.GetEvent(bindingModel.Id);
        var logicOrganisation = await _organisationCollection.GetOrganisationWithUsers(logicEvent.OrganisationId);

        Boolean userInOrganisation = logicOrganisation.Users.Any(user => user.Id == loggedInUserId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }


        var uiEvent = new Event(bindingModel);

        try
        {
            await _eventCollection.UpdateEvent(uiEvent.ConvertToModel());
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Details", new { id = bindingModel.Id });
        }


        return RedirectToAction("Details", new { id = uiEvent.Id });
    }


    //DELETE event
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        if (id == 0)
        {
            TempData["ErrorMessage"] = "No id given";

            // Handle validation errors
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }

        var logicEvent = await _eventCollection.GetEvent(id);
        var logicOrganisation = await _organisationCollection.GetOrganisationWithUsers(logicEvent.OrganisationId);

        Boolean userInOrganisation = logicOrganisation.Users.Any(user => user.Id == loggedInUserId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToAction("Manage", "OrganisationsAdmin");
        }

        try
        {
            await _eventCollection.DeleteEvent(id);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
        }

        return RedirectToAction("Manage");
    }
}
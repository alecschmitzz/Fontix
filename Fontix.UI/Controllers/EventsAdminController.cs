using AutoMapper;
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
    public async Task<IActionResult> Create(EventBindingModel bindingModel)
    {
        if (bindingModel == null)
        {
            throw new Exception("empty values");
        }

        var uiEvent = new Event(bindingModel);

        // check if user is part of companyId
        // int userId = _sessionAccess.GetUserId();
        //
        // if (userId == 0)
        // {
        //     return RedirectToAction("Login", "User");
        // }
        //
        // uiEvent.OrganisationId = userId;

        var logicEvent = uiEvent.ConvertToModel();
        try
        {
            await _eventCollection.InsertEvent(logicEvent);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("Manage");
    }

    //READ EVENTS
    public async Task<IActionResult> Manage(int? id)
    {
        if (id == null)
        {
            // GET THE FIRST ORGANISATION OF THE USER
            //TODO: FIX HARDCODE
            var userOrganisations = await _organisationCollection.GetUserOrganisations(1);
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

        List<Event> uiEvents = new List<Event>();

        if (id != null)
        {
            var logicEvents = await _eventCollection.GetOrganisationEvents((int)id);
            uiEvents = logicEvents.Select(logicEvent => new Event(logicEvent)).ToList();
        }


        //TODO: only select organisations connected to user
        //TODO: FIX HARDCODE
        var logicOrganisations = await _organisationCollection.GetUserOrganisations(1);
        var uiOrganisations = logicOrganisations.Select(logicOrganisation => new Organisation(logicOrganisation))
            .ToList();

        var tupleModel = new Tuple<List<Event>, List<Organisation>, int>(uiEvents, uiOrganisations, (int)id);
        
        return View(tupleModel);
    }


    //READ EVENT
    public async Task<IActionResult> Details(int id)
    {
        var logicEvent = await _eventCollection.GetEventWithTickets(id);

        var uiEvent = new Event(logicEvent);

        return View(uiEvent);
    }

    //UPDATE event
    [HttpPost]
    public async Task<IActionResult> Edit(EventBindingModel bindingModel)
    {
        var uiEvent = new Event(bindingModel);
        if (uiEvent == null)
        {
            throw new Exception("empty values");
        }

        try
        {
            await _eventCollection.UpdateEvent(uiEvent.ConvertToModel());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("Details", new { id = uiEvent.Id });
    }


    //DELETE event
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
        {
            throw new Exception("empty values");
        }


        try
        {
            await _eventCollection.DeleteEvent(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("Manage");
    }
}
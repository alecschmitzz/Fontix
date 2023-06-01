using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class EventsController : Controller
{
    private readonly IEventCollection _eventCollection;
    private readonly IOrganiserCollection _organiserCollection;
    private readonly ISessionAccess _sessionAccess;


    public EventsController(IEventCollection eventCollection, IOrganiserCollection organiserCollection, ISessionAccess sessionAccess)
    {
        _eventCollection = eventCollection;
        _organiserCollection = organiserCollection;
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
        // uiEvent.OrganiserId = userId;

        var logicEvent = uiEvent.ConvertToModel();
        try
        {
            await _eventCollection.InsertEvent(logicEvent);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("ManageEvents");
    }

    //READ EVENTS
    public async Task<IActionResult> ManageEvents()
    {
        var logicEvents = await _eventCollection.GetAllEvents();
        var uiEvents = logicEvents.Select(logicEvent => new Event(logicEvent)).ToList();
        
        //TODO: only select organisers connected to user
        var logicOrganisers = await _organiserCollection.GetAllOrganisers();
        var uiOrganisers = logicOrganisers.Select(logicOrganiser => new Organiser(logicOrganiser)).ToList();
        
        
        var tupleModel = new Tuple<List<Event>, List<Organiser>>(uiEvents, uiOrganisers);

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

        return RedirectToAction("ManageEvents");
    }
}
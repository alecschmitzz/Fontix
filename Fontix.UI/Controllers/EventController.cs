using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class EventController : Controller
{
    private readonly IEventCollection _eventCollection;
    private readonly IMapper _mapper;
    private readonly ISessionAccess _sessionAccess;


    public EventController(IEventCollection eventCollection, IMapper mapper, ISessionAccess sessionAccess)
    {
        _eventCollection = eventCollection;
        _mapper = mapper;
        _sessionAccess = sessionAccess;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Models.Event uiEvent)
    {
        if (uiEvent == null)
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
        // uiEvent.OrganiserId = userId;

        Fontix.Models.Event logicEvent = _mapper.Map<Fontix.Models.Event>(uiEvent);
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

    
    public async Task<IActionResult> ManageEvents()
    {
        var events = await _eventCollection.GetAllEvents();

        return View(events.Select(r => _mapper.Map<Models.Event>(r)));
    }
    

    //DETAILS
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var logicEvent = await _eventCollection.GetEvent(id.Value);

        if (logicEvent == null)
        {
            return NotFound();
        }

        var uiEvent = _mapper.Map<Fontix.UI.Models.Event>(logicEvent);

        return View(uiEvent);
    }

    //EDIT event
    [HttpPost]
    public async Task<IActionResult> Edit(Fontix.UI.Models.Event uiEvent)
    {
        if (uiEvent == null)
        {
            throw new Exception("empty values");
        }

        Fontix.Models.Event logicEvent = _mapper.Map<Fontix.Models.Event>(uiEvent);
        try
        {
            await _eventCollection.UpdateEvent(logicEvent);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("ManageEvents");
    }
    

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


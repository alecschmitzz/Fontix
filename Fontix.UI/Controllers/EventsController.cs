using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Models;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class EventsController : Controller
{
    private readonly IEventCollection _eventCollection;
    private readonly IOrganisationCollection _organisationCollection;
    private readonly ISessionAccess _sessionAccess;


    public EventsController(IEventCollection eventCollection, IOrganisationCollection organisationCollection,
        ISessionAccess sessionAccess)
    {
        _eventCollection = eventCollection;
        _organisationCollection = organisationCollection;
        _sessionAccess = sessionAccess;
    }

    //READ EVENTS
    public async Task<IActionResult> Index(int? id)
    {
        var logicEvents = await _eventCollection.GetAllEventsWithTickets();
        var uiEvents = logicEvents.Select(logicEvent => new Event(logicEvent)).ToList();
        
        return View(uiEvents);
    }
}
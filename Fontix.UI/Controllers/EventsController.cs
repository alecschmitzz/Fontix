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
}
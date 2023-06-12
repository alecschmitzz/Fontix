using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class OrderController : Controller
{
    private readonly IEventCollection _eventCollection;
    private readonly IOrganisationCollection _organisationCollection;
    private readonly ISessionAccess _sessionAccess;


    public OrderController(IEventCollection eventCollection, IOrganisationCollection organisationCollection,
        ISessionAccess sessionAccess)
    {
        _eventCollection = eventCollection;
        _organisationCollection = organisationCollection;
        _sessionAccess = sessionAccess;
    }

    public async Task<IActionResult> FillDetails()
    {
        // Get the selected tickets from the session
        var tickets = _sessionAccess.GetSelectedTickets();

        return View(tickets);
    }


    [HttpPost]
    public async Task<IActionResult> SaveSelectedTickets(Dictionary<int, SelectedTicketBindingModel> bindingModelList)
    {
        var selectedTickets = bindingModelList.Values.Select(item => new SelectedTicket(item)).ToList();
        
        // Save the selected tickets in the session
        _sessionAccess.SetSelectedTickets(selectedTickets);

        return RedirectToAction("FillDetails");
    }
}
using Fontix.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Fontix.Controllers;

public class EventController : Controller
{

    private readonly IEventRepository _eventRepo;
    
    
    // GET
    public EventController(IEventRepository eventRepo)
    {
        _eventRepo = eventRepo;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }


    public async Task<IActionResult> GetEvents()
    {
        var events = await _eventRepo.GetEvents();
        return Ok(events);
    }
}
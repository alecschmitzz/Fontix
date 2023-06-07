using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fontix.UI.Models;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISessionAccess _sessionAccess;

    public HomeController(ILogger<HomeController> logger, ISessionAccess sessionAccess)
    {
        _logger = logger;
        _sessionAccess = sessionAccess;
    }

    public IActionResult Index()
    {
        return View(_sessionAccess.GetUserId());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
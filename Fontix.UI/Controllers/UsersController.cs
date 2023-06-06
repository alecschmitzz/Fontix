using Fontix.IBLL.Collections;
using Fontix.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Fontix.UI.Controllers;

public class UsersController : Controller
{
    private readonly IUserCollection _userCollection;


    public UsersController(IUserCollection userCollection)
    {
        _userCollection = userCollection;
    }

    public async Task<IActionResult> Login(Boolean afterRegister = false)
    {
        if (afterRegister)
        {
            ViewBag.SuccessMessage = "You can now login";
        }

        return View();
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginBindingModel bindingModel)
    {
        var user = await _userCollection.AuthenticateAndGetUser(bindingModel.Email, bindingModel.Password);

        if (user != null && user.Id != null)
        {
            // Save userId to session
            HttpContext.Session.SetInt32("UserId", (int)user.Id);

            // Authentication successful
            // Redirect to the home page or any other authenticated page
            return RedirectToAction("Index", "Home");
        }

        // Authentication failed
        // Display an error message
        ViewBag.ErrorMessage = "Invalid username or password";
        return View(bindingModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterBindingModel bindingModel)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Fill in all the required fields";

            // Handle validation errors
            return View(bindingModel);
        }

        var logicUser = await _userCollection.GetUserByEmail(bindingModel.Email);

        if (logicUser != null)
        {
            ViewBag.ErrorMessage = "User with e-mail already exists";
            return View(bindingModel);
        }

        var uiUser = new Fontix.UI.Models.User(bindingModel);

        await _userCollection.InsertUser(uiUser.ConvertToModel());

        return RedirectToAction("Login", new { afterRegister = true });
    }
}
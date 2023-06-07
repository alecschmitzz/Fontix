using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class OrganisationsAdminController : Controller
{
    private readonly IOrganisationCollection _organisationCollection;
    private readonly IUserCollection _userCollection;
    private readonly ISessionAccess _sessionAccess;


    public OrganisationsAdminController(IOrganisationCollection organisationCollection, IUserCollection userCollection,
        ISessionAccess sessionAccess)
    {
        _organisationCollection = organisationCollection;
        _userCollection = userCollection;
        _sessionAccess = sessionAccess;
    }

    //CREATE ORGANISATION
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrganisationBindingModel bindingModel)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Fill in all the required fields";
            // Handle validation errors
            return RedirectToAction("Manage");
        }

        var loggedInUserId = _sessionAccess.GetUserId();

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        var uiOrganisation = new Organisation(bindingModel);

        var logicOrganisation = uiOrganisation.ConvertToModel();
        try
        {
            await _organisationCollection.InsertOrganisation(logicOrganisation, loggedInUserId);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
        }


        return RedirectToAction("Manage");
    }

    //READ ORGANISATIONS
    public async Task<IActionResult> Manage()
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.LoggedInUserId = loggedInUserId;

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        var logicOrganisations = await _organisationCollection.GetUserOrganisations(loggedInUserId);
        var uiOrganisations = logicOrganisations.Select(logicOrganisation => new Organisation(logicOrganisation))
            .ToList();


        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;
        return View(uiOrganisations);
    }

    //READ ORGANISATION -> PEOPLE
    public async Task<IActionResult> People(int id)
    {
        var loggedInUserId = _sessionAccess.GetUserId();

        ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;
        ViewBag.LoggedInUserId = loggedInUserId;

        if (loggedInUserId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }

        if (id == 0)
        {
            ViewBag.ErrorMessage = "No organisation set";
            return RedirectToAction("Manage");
        }

        var logicOrganisation = await _organisationCollection.GetOrganisationWithUsers(id);

        Boolean userInOrganisation = logicOrganisation.Users.Any(user => user.Id == loggedInUserId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToAction("Manage");
        }

        var uiOrganisation = new Organisation(logicOrganisation);

        return View(uiOrganisation);
    }

    //ADD MEMBER
    [HttpPost]
    public async Task<IActionResult> AddMember(AddMemberBindingModel bindingModel)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Fill in all the required fields";
            // Handle validation errors
            return RedirectToAction("People", new { bindingModel.OrganisationId });
        }

        //GET LOGGED IN USER ID
        var userId = _sessionAccess.GetUserId();

        if (userId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }


        //CHECK IF LOGGED IN USER IS PART OF ORGANISATION
        var logicOrganisationWithUsers =
            await _organisationCollection.GetOrganisationWithUsers(bindingModel.OrganisationId);

        Boolean userInOrganisation = logicOrganisationWithUsers.Users.Any(user => user.Id == userId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToRoute(new
            {
                action = "People",
                id = bindingModel.OrganisationId
            });
        }

        //CHECK IF NEW USER EMAIL EXISTS
        var logicUser =
            await _userCollection.GetUserByEmail(bindingModel.Email);

        if (logicUser == null)
        {
            TempData["ErrorMessage"] = "User e-mail is not registered";
            // Handle errors
            return RedirectToRoute(new
            {
                action = "People",
                id = bindingModel.OrganisationId
            });
        }

        try
        {
            await _organisationCollection.AddMember(bindingModel.OrganisationId, logicUser.Id);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            // Handle errors
            return RedirectToRoute(new
            {
                action = "People",
                id = bindingModel.OrganisationId
            });
        }


        return RedirectToRoute(new
        {
            action = "People",
            id = bindingModel.OrganisationId
        });
    }

    //REMOVE MEMBER
    [HttpPost]
    public async Task<IActionResult> RemoveMember(RemoveMemberBindingModel bindingModel)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Fill in all the required fields";
            // Handle validation errors
            return RedirectToAction("People", new { bindingModel.OrganisationId });
        }

        //GET LOGGED IN USER ID
        var userId = _sessionAccess.GetUserId();

        if (userId == 0)
        {
            TempData["ErrorMessage"] = "User not logged in";
            return RedirectToAction("Login", "Users");
        }


        //CHECK IF LOGGED IN USER IS PART OF ORGANISATION
        var logicOrganisationWithUsers =
            await _organisationCollection.GetOrganisationWithUsers(bindingModel.OrganisationId);

        Boolean userInOrganisation = logicOrganisationWithUsers.Users.Any(user => user.Id == userId);

        if (!userInOrganisation)
        {
            TempData["ErrorMessage"] = "Logged in user is not part of organisation";
            // Handle errors
            return RedirectToRoute(new
            {
                action = "People",
                id = bindingModel.OrganisationId
            });
        }

        if (userId == bindingModel.UserId)
        {
            TempData["ErrorMessage"] = "You can't remove yourself";
            return RedirectToAction("Login", "Users");
        }

        try
        {
            await _organisationCollection.RemoveMember(bindingModel.OrganisationId, bindingModel.UserId);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            // Handle errors
            return RedirectToRoute(new
            {
                action = "People",
                id = bindingModel.OrganisationId
            });
        }


        return RedirectToRoute(new
        {
            action = "People",
            id = bindingModel.OrganisationId
        });
    }

    //UPDATE ORGANISATION
    [HttpPost]
    public async Task<IActionResult> Edit(EditOrganisationBindingModel bindingModel)
    {
        var uiOrganisation = new Organisation(bindingModel);
        if (uiOrganisation == null)
        {
            throw new Exception("empty values");
        }

        try
        {
            await _organisationCollection.UpdateOrganisation(uiOrganisation.ConvertToModel());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("Manage");
    }

    //DELETE ORGANISATION
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
        {
            throw new Exception("empty values");
        }


        try
        {
            await _organisationCollection.DeleteOrganisation(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("Manage");
    }
}
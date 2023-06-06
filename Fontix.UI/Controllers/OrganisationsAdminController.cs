using Microsoft.AspNetCore.Mvc;
using Fontix.IBLL.Collections;
using Fontix.UI.Models;
using Fontix.UI.Models.BindingModels;
using Fontix.UI.Utils;

namespace Fontix.UI.Controllers;

public class OrganisationsAdminController : Controller
{
    private readonly IOrganisationCollection _organisationCollection;
    private readonly ISessionAccess _sessionAccess;


    public OrganisationsAdminController(IOrganisationCollection organisationCollection, ISessionAccess sessionAccess)
    {
        _organisationCollection = organisationCollection;
        _sessionAccess = sessionAccess;
    }

    //CREATE EVENT
    [HttpPost]
    public async Task<IActionResult> Create(OrganisationBindingModel bindingModel)
    {
        if (bindingModel == null)
        {
            throw new Exception("empty values");
        }

        var uiOrganisation = new Organisation(bindingModel);

        // check if user is part of companyId
        // int userId = _sessionAccess.GetUserId();
        //
        // if (userId == 0)
        // {
        //     return RedirectToAction("Login", "User");
        // }
        //
        // uiEvent.OrganisationId = userId;

        var logicOrganisation = uiOrganisation.ConvertToModel();
        try
        {
            await _organisationCollection.InsertOrganisation(logicOrganisation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        return RedirectToAction("Manage");
    }

    //READ EVENTS
    public async Task<IActionResult> Manage()
    {
        //TODO: FIX HARDCODED
        var logicOrganisations = await _organisationCollection.GetUserOrganisations(1);
        var uiOrganisations = logicOrganisations.Select(logicOrganisation => new Organisation(logicOrganisation)).ToList();
        return View(uiOrganisations);
    }

    //UPDATE organisation
    [HttpPost]
    public async Task<IActionResult> Edit(OrganisationBindingModel bindingModel)
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
            await _organisationCollection.DeleteOrganisation(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return RedirectToAction("Manage");
    }
}
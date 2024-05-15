namespace Contacts.Controllers;

using Contacts.Services.Contracts;
using Contacts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
public class ContactsController : Controller
{
    private readonly IContactsService _contactsService;

    public ContactsController(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public async Task<IActionResult> All()
    {
        var allContacts = await _contactsService.GetAllContactsAsync();

        return View(allContacts);
    }

    public async Task<IActionResult> Team()
    {
        var userId = GetUserId();

        var myTeamContacts = await _contactsService.GetMyTeamContactsAsync(userId);

        return View(myTeamContacts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        ContactFormModel model = new ContactFormModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ContactFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _contactsService.AddContactAsync(model);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("All", "Contacts");
    }

    [HttpPost]
    public async Task<IActionResult> AddToTeam(string contactId)
    {
        var userId = GetUserId();

        try
        {
            await _contactsService.AddToMyTeamAsync(userId, contactId);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("All", "Contacts");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromTeam(string contactId)
    {
        var userId = GetUserId();

        try
        {
            await _contactsService.RemoveFromMyTeamAsync(userId, contactId);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("Team", "Contacts");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var contact = await _contactsService.GetContactById(id);

        if (contact == null) { return NotFound(); }

        return View(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, ContactFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _contactsService.EditContactAsync(id, model);
        }
        catch
        {

            BadRequest();
        }

        return RedirectToAction("All", "Contacts");
    }

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
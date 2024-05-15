namespace Contacts.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using ViewModels;
using Contracts;

[Authorize]
public class ContactsController : Controller
{
    private readonly IContractsService _service;

    public ContactsController(IContractsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> All()
    {
        var contacts = await _service.GetAllContacts();

        return View(contacts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        ContactFormModel formModel = new ContactFormModel();
        return View(formModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ContactFormModel formModel)
    {
        if (!ModelState.IsValid)
        {
            return View(formModel);
        }

        await _service.AddContact(formModel);

        return RedirectToAction("All", "Contacts");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var formModel = await _service.GetContactById(id);

        if (formModel == null)
        {
            return NotFound();
        }

        return View(formModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ContactFormModel formModel)
    {
        if (!ModelState.IsValid)
        {
            return View(formModel);
        }

        try
        {
            await _service.UpdateContact(id, formModel);
        }
        catch
        {
            return BadRequest();
        }

        return RedirectToAction("All", "Contacts");
    }

    [HttpPost]
    public async Task<IActionResult> AddToTeam(int contactId)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        try
        {
            await _service.AddContactToTeam(userId, contactId);
        }
        catch
        {
            return BadRequest();
        }

        return RedirectToAction("All", "Contacts");
    }

    public async Task<IActionResult> Team()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var contacts = await _service.GetAllTeamContacts(userId);

        return View(contacts);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromTeam(int contactId)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        try
        {
            await _service.DeleteContactFromTeam(userId, contactId);
        }
        catch
        {
            return BadRequest();
        }

        return RedirectToAction("Team", "Contacts");
    }
}
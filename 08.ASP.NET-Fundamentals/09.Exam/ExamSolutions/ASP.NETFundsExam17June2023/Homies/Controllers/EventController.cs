namespace Homies.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Homies.Core.Contracts;
using Homies.Core.Models;

[Authorize]
public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<IActionResult> All()
    {
        var events = await _eventService.GetAllEventsAsync();

        return View(events);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var types = await _eventService.GetEventTypesAsync();

        EventFormViewModel model = new EventFormViewModel
        {
            Types = types
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        var types = await _eventService.GetEventTypesAsync();

        model.Types = types;
        model.CreatedOn = DateTime.Now;//.ToString("dd-MM-yyyy H:mm", CultureInfo.InvariantCulture);
        model.OrganiserId = GetUserID();

        //ModelState.SetModelValue("CreatedOn", new ValueProviderResult(model.CreatedOn));
        //ModelState.SetModelValue("OrganiserId", new ValueProviderResult(model.OrganiserId = GetUserID()));
        ModelState.Remove("OrganiserId");

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _eventService.AddEvent(model);
        }
        catch
        {
           return BadRequest();
        }

        return RedirectToAction("All", "Event");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var types = await _eventService.GetEventTypesAsync();

        var eventToEdit = await _eventService.GetEventById(id);

        eventToEdit.Types = types;

        var currentUserId = GetUserID();

        if (currentUserId != eventToEdit.OrganiserId)
        {
            return RedirectToAction("All", "Event");
        }

        return View(eventToEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EventFormViewModel model)
    {
        var types = await _eventService.GetEventTypesAsync();

        var currentEvent = await _eventService.GetEventById(id);

        currentEvent.Types = types;
        model.Types = types;

        //model.CreatedOn = DateTime.Now;//.ToString("dd-MM-yyyy H:mm", CultureInfo.InvariantCulture);
        //model.OrganiserId = GetUserID();

        ModelState.Remove("OrganiserId");

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        currentEvent.Name = model.Name;
        currentEvent.Description = model.Description;
        currentEvent.Start = model.Start;
        currentEvent.End = model.End;
        currentEvent.TypeId = model.TypeId;

        try
        {
            await _eventService.UpdateEvent(id, currentEvent);
        }
        catch
        {
            return BadRequest();
        }

        return RedirectToAction("All", "Event");
    }

    public async Task<IActionResult> Joined()
    {
        string userId = GetUserID();

        var joinedEvents = await _eventService.GetAllJoinedEventsAsync(userId);

        return View(joinedEvents);
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var userId = GetUserID();

        var alreadyJoined = await _eventService.GetAllJoinedEventsAsync(userId);

        if (alreadyJoined.Any(x => x.Id == id))
        {
            return RedirectToAction("All", "Event");
        }

        await _eventService.AddEventToJoinedEvents(userId, id);

        return RedirectToAction("Joined", "Event");
    }

    public async Task<IActionResult> Details(int id)
    {
        var eventDetails = await _eventService.GetEventDetailsById(id);

        return View(eventDetails);
    }

    public async Task<IActionResult> Leave(int id)
    {
        var userId = GetUserID();

        try
        {
            await _eventService.RemoveEventFromJoinedEvents(userId, id);
        }
        catch
        {
            return BadRequest();
        }

        return RedirectToAction("All", "Event");
    }
    private string GetUserID() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
namespace Homies.Core.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Homies.Core.Contracts;
using Homies.Core.Models;
using Homies.Data;
using Homies.Data.Entities;
using System.Globalization;

public class EventServices : IEventService
{
    private readonly HomiesDbContext _data;

    public EventServices(HomiesDbContext dbContext)
    {
        _data = dbContext;
    }

    public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
    {
        var events = await _data.Events
            .Select(e => new EventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                OrganiserId = e.OrganiserId,
                Organiser = e.Organiser,
                CreatedOn = e.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                Start = e.Start.ToString("dd-MM-yyyy H:mm"),
                End = e.End.ToString("dd-MM-yyyy H:mm"),
                TypeId = e.TypeId,
                Type = e.Type.Name,
            })
            .ToListAsync();

        return events;
    }

    public async Task<IEnumerable<TypeViewModel>> GetEventTypesAsync()
    {
        var types = await _data.Types
            .Select(t => new TypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();

        return types;
    }

    public async Task AddEvent(EventFormViewModel model)
    {
        Event newEvent = new Event()
        {
            Name = model.Name,
            Description = model.Description,
            OrganiserId = model.OrganiserId,
            CreatedOn = model.CreatedOn,//(DateTime.ParseExact(model.CreatedOn, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture)),
            Start = (DateTime.ParseExact(model.Start, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture)),
            End = (DateTime.ParseExact(model.End, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture)),
            TypeId = model.TypeId
        };

        await _data.Events.AddAsync(newEvent);
        await _data.SaveChangesAsync();
    }

    public async Task<EventFormViewModel> GetEventById(int id)
    {
        var eventById = await _data.Events.FindAsync(id);

        if (eventById != null)
        {
            EventFormViewModel eventFormModel = new EventFormViewModel()
            {
                Name = eventById.Name,
                Description = eventById.Description,
                OrganiserId = eventById.OrganiserId,
                CreatedOn = eventById.CreatedOn,//eventById.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                Start = eventById.Start.ToString("dd-MM-yyyy H:mm"),
                End = eventById.End.ToString("dd-MM-yyyy H:mm"),
                TypeId = eventById.TypeId
            };

            return eventFormModel;
        }

        return null;
    }

    public async Task UpdateEvent(int id, EventFormViewModel model)
    {
        var eventToUpdate = await _data.Events.FindAsync(id);

        if (eventToUpdate != null)
        {
            eventToUpdate.Name = model.Name;
            eventToUpdate.Description = model.Description;
            eventToUpdate.OrganiserId = model.OrganiserId;
            eventToUpdate.CreatedOn = model.CreatedOn;//(DateTime.ParseExact(model.CreatedOn, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture));
            eventToUpdate.Start = (DateTime.ParseExact(model.Start, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture));
            eventToUpdate.End = (DateTime.ParseExact(model.End, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture));
            eventToUpdate.TypeId = model.TypeId;
        }

        await _data.SaveChangesAsync();
    }

    public async Task<IEnumerable<EventViewModel>> GetAllJoinedEventsAsync(string userId)
    {
        var events = await _data.EventsParticipants
            .Where(ep => ep.HelperId == userId)
            .Select(e => new EventViewModel
            {
                Id = e.Event.Id,
                Name = e.Event.Name,
                Description = e.Event.Description,
                OrganiserId = e.Event.OrganiserId,
                Organiser = e.Event.Organiser,
                CreatedOn = e.Event.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                Start = e.Event.Start.ToString("dd-MM-yyyy H:mm"),
                End = e.Event.End.ToString("dd-MM-yyyy H:mm"),
                TypeId = e.Event.TypeId,
                Type = e.Event.Type.Name
            })
            .ToListAsync();

        return events;
    }

    public async Task AddEventToJoinedEvents(string userId, int eventId)
    {
        EventParticipant eventParticipant = new EventParticipant()
        {
            HelperId = userId,
            EventId = eventId
        };

        if (!_data.EventsParticipants.Contains(eventParticipant))
        {
            await _data.EventsParticipants.AddAsync(eventParticipant);

            await _data.SaveChangesAsync();
        }
    }

    public async Task<EventDetailsViewModel> GetEventDetailsById(int id)
    {
        var taskDetails = await _data.Events
            .Where(e => e.Id == id)
            .Select(e => new EventDetailsViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                OrganiserId = e.OrganiserId,
                Organiser = e.Organiser,
                Start = e.Start,
                End = e.End,
                CreatedOn = e.CreatedOn,
                TypeId = e.TypeId,
                Type = e.Type.Name
            })
            .FirstOrDefaultAsync();

        return taskDetails;
    }

    public async Task RemoveEventFromJoinedEvents(string userId, int eventId)
    {
        var eventToRemove = await _data.EventsParticipants
            .Where(ep => ep.HelperId == userId && ep.EventId == eventId)
            .FirstOrDefaultAsync();

        if (eventToRemove != null)
        {
            _data.EventsParticipants.Remove(eventToRemove);

            await _data.SaveChangesAsync();
        }
    }
}
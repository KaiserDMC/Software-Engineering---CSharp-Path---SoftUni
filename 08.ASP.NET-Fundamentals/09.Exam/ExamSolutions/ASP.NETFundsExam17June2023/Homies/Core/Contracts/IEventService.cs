namespace Homies.Core.Contracts;

using Homies.Core.Models;

public interface IEventService
{
    Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

    Task<IEnumerable<TypeViewModel>> GetEventTypesAsync();

    Task AddEvent(EventFormViewModel model);

    Task<EventFormViewModel> GetEventById(int id);

    Task UpdateEvent(int id, EventFormViewModel model);

    Task<IEnumerable<EventViewModel>> GetAllJoinedEventsAsync(string userId);

    Task AddEventToJoinedEvents(string userId, int eventId);

    Task RemoveEventFromJoinedEvents(string userId, int eventId);

    Task <EventDetailsViewModel> GetEventDetailsById(int id);
}
namespace Contacts.Services.Contracts;

using Contacts.ViewModels;

public interface IContactsService
{
    Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();

    Task<IEnumerable<ContactViewModel>> GetMyTeamContactsAsync(string userId);

    Task AddContactAsync(ContactFormModel model);

    Task AddToMyTeamAsync(string userId, string contactId);

    Task RemoveFromMyTeamAsync(string userId, string contactId);

    Task<ContactFormModel> GetContactById(string contactId);

    Task EditContactAsync( string contactId, ContactFormModel model);
}
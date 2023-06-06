namespace Contacts.Contracts;

using ViewModels;

public interface IContractsService
{
    Task<ICollection<ContactViewModel>> GetAllContacts();

    Task<ICollection<ContactViewModel>> GetAllTeamContacts(string userId);

    Task AddContact(ContactFormModel model);

    Task<ContactFormModel> GetContactById(int contactId);

    Task UpdateContact(int contactId, ContactFormModel model);

    Task AddContactToTeam(string userId, int contactId);

    Task DeleteContactFromTeam(string userId, int contactId);
}
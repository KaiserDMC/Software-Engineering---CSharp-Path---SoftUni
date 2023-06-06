namespace Contacts.Services;

using Microsoft.EntityFrameworkCore;

using Contracts;
using Data;
using Data.Models;
using ViewModels;

public class ContactsServices : IContractsService
{
    private readonly ContactsDbContext _data;

    public ContactsServices(ContactsDbContext context)
    {
        _data = context;
    }

    public async Task<ICollection<ContactViewModel>> GetAllContacts()
    {
        var contacts = await _data.Contacts
            .Select(c => new ContactViewModel()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                Website = c.Website
            })
            .ToArrayAsync();

        return contacts;
    }

    public async Task<ICollection<ContactViewModel>> GetAllTeamContacts(string userId)
    {
        var userContacts = await _data.ApplicationUsersContacts
            .Where(u => u.ApplicationUserId == userId)
            .Select(u => u.Contact)
            .ToArrayAsync();

        var contacts = userContacts
            .Select(c => new ContactViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                Website = c.Website
            })
            .ToArray();

        return contacts;
    }

    public async Task AddContact(ContactFormModel model)
    {
        Contact contact = new Contact()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            Website = model.Website
        };

        await _data.Contacts.AddAsync(contact);
        await _data.SaveChangesAsync();
    }

    public async Task<ContactFormModel> GetContactById(int contactId)
    {
        var contact = await _data.Contacts.FindAsync(contactId);

        if (contact != null)
        {
            ContactFormModel contactModel = new ContactFormModel()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address,
                Website = contact.Website
            };

            return contactModel;
        }

        return null;

    }

    public async Task UpdateContact(int contactId, ContactFormModel model)
    {
        var contact = await _data.Contacts.FindAsync(contactId);

        if (contact != null)
        {
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Address = model.Address;
            contact.Website = model.Website;
        }

        await _data.SaveChangesAsync();
    }

    public async Task AddContactToTeam(string userId, int id)
    {
        var contact = await _data.Contacts.FindAsync(id);

        if (contact == null)
        {
            return;
        }

        ApplicationUserContact user = new ApplicationUserContact()
        {
            ContactId = contact.Id,
            ApplicationUserId = userId
        };

        if (!_data.ApplicationUsersContacts.Contains(user))
        {
            _data.ApplicationUsersContacts.Add(user);

            await _data.SaveChangesAsync();
        }
    }

    public async Task DeleteContactFromTeam(string userId, int contactId)
    {
        var userContacts = await _data.Users
            .Where(u => u.Id == userId)
            .Select(u => u.ApplicationUsersContacts)
            .FirstOrDefaultAsync();

        if (userContacts == null)
        {
            throw new ArgumentException("No such user exists.");
        }

        var userToRemove = userContacts.FirstOrDefault(c => c.ContactId == contactId);

        _data.ApplicationUsersContacts.Remove(userToRemove);

        await _data.SaveChangesAsync();
    }
}
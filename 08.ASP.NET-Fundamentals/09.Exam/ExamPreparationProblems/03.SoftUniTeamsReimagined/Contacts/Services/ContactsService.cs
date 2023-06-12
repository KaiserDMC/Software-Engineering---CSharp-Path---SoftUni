namespace Contacts.Services;

using Microsoft.EntityFrameworkCore;

using Contacts.Data;
using Contacts.Data.Entities;
using Contacts.Services.Contracts;
using Contacts.ViewModels;

public class ContactsService : IContactsService
{
    private readonly ContactsDbContext _data;

    public ContactsService(ContactsDbContext context)
    {
        _data = context;
    }

    public async Task<IEnumerable<ContactViewModel>> GetAllContactsAsync()
    {
        var allContacts = await _data.Contacts
            .Select(c => new ContactViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.PhoneNumber,
                Address = c.Address,
                Website = c.Website
            })
            .ToListAsync();

        return allContacts;
    }

    public async Task<IEnumerable<ContactViewModel>> GetMyTeamContactsAsync(string userId)
    {
        var currentUser = await _data.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        var myTeamContacts = await _data.Contacts
            .Where(c => c.ApplicationUsersContacts.Any(auc => auc.ApplicationUser == currentUser))
            .Select(c => new ContactViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.PhoneNumber,
                Address = c.Address,
                Website = c.Website
            })
            .ToListAsync();

        return myTeamContacts;
    }

    public async Task AddContactAsync(ContactFormModel model)
    {
        Contact contact = new Contact()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.Phone,
            Address = model.Address,
            Website = model.Website
        };

        await _data.Contacts.AddAsync(contact);
        await _data.SaveChangesAsync();
    }

    public async Task AddToMyTeamAsync(string userId, string contactId)
    {
        ApplicationUserContact applicationUserContact = new ApplicationUserContact
        {
            ApplicationUserId = userId,
            ContactId = Guid.Parse(contactId)
        };

        if (!_data.ApplicationUsersContacts.Contains(applicationUserContact))
        {
            _data.ApplicationUsersContacts.Add(applicationUserContact);

            await _data.SaveChangesAsync();
        }
    }

    public async Task RemoveFromMyTeamAsync(string userId, string contactId)
    {
        var currentUser = await _data.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (currentUser != null)
        {
            var contactToRemove = await _data.ApplicationUsersContacts
                .FirstOrDefaultAsync(auc => auc.ApplicationUser == currentUser && auc.ContactId == Guid.Parse(contactId));

            if (contactToRemove != null)
            {
                _data.ApplicationUsersContacts.Remove(contactToRemove);

                await _data.SaveChangesAsync();
            }
        }
    }

    public async Task<ContactFormModel> GetContactById(string contactId)
    {
        var contactToEdit = await _data.Contacts.FindAsync(Guid.Parse(contactId));

        if (contactToEdit != null)
        {
            ContactFormModel model = new ContactFormModel
            {
                FirstName = contactToEdit.FirstName,
                LastName = contactToEdit.LastName,
                Email = contactToEdit.Email,
                Phone = contactToEdit.PhoneNumber,
                Address = contactToEdit.Address,
                Website = contactToEdit.Website
            };

            return model;
        }

        return null;
    }

    public async Task EditContactAsync(string contactId, ContactFormModel model)
    {
        var contactToEdit = await _data.Contacts.FindAsync(Guid.Parse(contactId));

        if (contactToEdit != null)
        {
            contactToEdit.FirstName = model.FirstName;
            contactToEdit.LastName = model.LastName;
            contactToEdit.Email = model.Email;
            contactToEdit.PhoneNumber = model.Phone;
            contactToEdit.Address = model.Address;                    
            contactToEdit.Website = model.Website;      
        }

        await _data.SaveChangesAsync();
    }
}
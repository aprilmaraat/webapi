using Microsoft.EntityFrameworkCore;
using webapi.EF;
using webapi.EF.Models;
using webapi.Utilities.HelperModels;
using webapi.DTOs;

namespace webapi.Services
{
    public class ContactService : IContactService
    {
        private readonly WebApiContext _context;

        public ContactService(WebApiContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Contact>> GetContactsAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Contacts.CountAsync();
            var items = await _context.Contacts
                .Include(c => c.Location)
                .Include(c => c.WorkType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Contact>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> CreateContactAsync(ContactDTO contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            // Ensure all required parameters are passed to the Contact constructor
            var newContact = new Contact
            {
                Id = contact.Id,
                Email = contact.Email,
                FullName = contact.FullName,
                MobileNumber = contact.MobileNumber,
                LocationId = contact.LocationId ?? Guid.Empty, // Handle nullable LocationId
                WorkTypeId = contact.WorkTypeId ?? 0, // Handle nullable WorkTypeId
            };

            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();
            return newContact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }
        public async Task<bool> DeleteContactAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false; // Contact not found
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true; // Contact deleted successfully
        }
    }
}

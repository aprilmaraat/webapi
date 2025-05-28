using webapi.EF.Models;
using webapi.Utilities.HelperModels;
using webapi.DTOs;

namespace webapi.Services
{
    public interface IContactService
    {
        Task<PagedResult<Contact>> GetContactsAsync(int pageNumber, int pageSize);
        Task<Contact?> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(ContactDTO contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(Guid id);
    }
}

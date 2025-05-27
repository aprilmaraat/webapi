using webapi.EF.Models;
using webapi.Utilities.HelperModels;

namespace webapi.Services
{
    public interface IContactService
    {
        Task<PagedResult<Contact>> GetContactsAsync(int pageNumber, int pageSize);
        Task<Contact?> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(Guid id);
    }
}

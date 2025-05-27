using webapi.EF.Models;
using webapi.Utilities.HelperModels;

namespace webapi.Services
{
    public interface IContactService
    {
        Task<PagedResult<Contact>> GetContactsAsync(int pageNumber, int pageSize);
    }
}

using Microsoft.EntityFrameworkCore;
using webapi.EF;
using webapi.EF.Models;
using webapi.Utilities.HelperModels;

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
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Contact>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}

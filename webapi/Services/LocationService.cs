using Microsoft.EntityFrameworkCore;
using webapi.EF;
using webapi.EF.Models;
using webapi.Utilities.HelperModels;

namespace webapi.Services
{
    public class LocationService : ILocationService
    {
        private readonly WebApiContext _context;

        public LocationService(WebApiContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Location>> GetLocationsAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Locations.CountAsync();
            var items = await _context.Locations
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Location>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}

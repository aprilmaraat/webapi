using webapi.EF.Models;
using webapi.Utilities.HelperModels;

namespace webapi.Services
{
    public interface ILocationService
    {
        Task<PagedResult<Location>> GetLocationsAsync(int pageNumber, int pageSize);
    }
}

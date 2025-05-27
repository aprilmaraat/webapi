using webapi.EF;
using Microsoft.EntityFrameworkCore;

namespace webapi.Services
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly WebApiContext _context;

        public WorkTypeService(WebApiContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetWorkTypesAsync()
        {
            return await _context.WorkTypes
                .Select(workType => workType.Name)
                .ToListAsync();
        }
    }
}

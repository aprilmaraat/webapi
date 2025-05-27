using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService) : base() 
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }

            var result = await _locationService.GetLocationsAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}
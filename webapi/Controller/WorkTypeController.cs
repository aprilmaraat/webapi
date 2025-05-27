using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeService _workTypeService;
        public WorkTypeController(IWorkTypeService workTypeService)
        {
            _workTypeService = workTypeService ?? throw new ArgumentNullException(nameof(workTypeService));
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkTypesAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }
            var result = await _workTypeService.GetWorkTypesAsync();
            return Ok(result);
        }
    }
}

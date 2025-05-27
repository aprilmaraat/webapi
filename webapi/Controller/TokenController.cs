using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService) : base()
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetToken([FromQuery] string userId, [FromQuery] string role)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
            {
                return BadRequest("UserId and Role must be provided.");
            }
            var token = _tokenService.GenerateToken(userId, role);
            return Ok(new { Token = token });
        }
    }
}

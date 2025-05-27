using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.EF.Models;
using webapi.Services;

namespace webapi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }
            var result = await _contactService.GetContactsAsync(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0.");
            }
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound($"Contact with Id {id} not found.");
            }
            return Ok(contact);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact cannot be null.");
            }
            var createdContact = await _contactService.CreateContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] Contact contact)
        {
            if (id == Guid.Empty || contact == null)
            {
                return BadRequest("Id required and Contact cannot be null.");
            }
            var updatedContact = await _contactService.UpdateContactAsync(contact);
            if (updatedContact == null)
            {
                return NotFound($"Contact with Id {id} not found.");
            }
            return Ok(updatedContact);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id must be greater than 0.");
            }
            var deleted = await _contactService.DeleteContactAsync(id);
            if (!deleted)
            {
                return NotFound($"Contact with Id {id} not found.");
            }
            return NoContent();
        }
    }
}

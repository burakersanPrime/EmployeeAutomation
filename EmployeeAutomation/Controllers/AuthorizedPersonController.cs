using em.Application.AuthInterface;
using em.Application.Interface;
using em.Domain.Authorize;
using em.Domain.AuthorizeDto;
using em.Domain.Entity;
using em.Domain.EntityDto;
using em.Persistence.AuthRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EmployeeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizedPersonController : ControllerBase
    {
        private readonly IAuthorizedPersonRepository _authorizedPersonRepository;
        private readonly ILogger<AuthorizedPersonController> _logger;


        public AuthorizedPersonController(IAuthorizedPersonRepository authorizedPersonRepository, ILogger<AuthorizedPersonController> logger)
        {
            _authorizedPersonRepository = authorizedPersonRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<AuthorizedPerson>> GetAuthorizedPersons()
        {
            try
            {
                var authorizedPersons = _authorizedPersonRepository.GetAll();
                return authorizedPersons;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorizedPerson(int id)
        {
            var authorizedPerson = _authorizedPersonRepository.GetById(id);
            if (authorizedPerson == null)
                return NotFound();

            return Ok(authorizedPerson);
        }

        [HttpPost]
        public IActionResult CreateAuthorizedPerson(AuthorizedPersonDto authorizedPersonDto)
        {
            var authorizedPerson = new AuthorizedPerson
            {
                Name = authorizedPersonDto.Name,
                Surname = authorizedPersonDto.Surname,
                authorizationID = authorizedPersonDto.roleID
            };

            _authorizedPersonRepository.Add(authorizedPerson);
            return CreatedAtAction(nameof(GetAuthorizedPerson), new { id = authorizedPerson.ID }, authorizedPerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthorizedPerson(int id, AuthorizedPersonDto authorizedPersonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAuthorizedPerson = _authorizedPersonRepository.GetById(id);

            existingAuthorizedPerson.Name = authorizedPersonDto.Name;
            existingAuthorizedPerson.Surname = authorizedPersonDto.Surname;
            existingAuthorizedPerson.authorizationID = authorizedPersonDto.roleID;

            _authorizedPersonRepository.Update(existingAuthorizedPerson);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorizedPerson(int id)
        {
            try
            {
                _authorizedPersonRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}

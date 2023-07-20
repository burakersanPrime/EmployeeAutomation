using em.Application.AuthInterface;
using em.Application.Interface;
using em.Domain.Authorize;
using em.Domain.AuthorizeDto;
using em.Domain.Entity;
using em.Domain.EntityDto;
using em.Persistence.AuthRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAutomation.Controllers
{
    // Admin.
    
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public List<Roles> GetRoles()
        {
            var roles = _rolesRepository.GetAll();
            return roles;
        }

        [HttpGet("{id}")]
        public IActionResult GetRoles(int id)
        {
            var roles = _rolesRepository.GetById(id);
            if (roles == null)
                return NotFound();

            return Ok(roles);
        }

        [HttpPost]
        public IActionResult CreateRoles(RolesDto rolesDto)
        {
            var roles = new Roles
            {
                Name = rolesDto.Name,
            };

            _rolesRepository.Add(roles);
            return CreatedAtAction(nameof(GetRoles), new { id = roles.ID }, roles);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoles(int id, RolesDto rolesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRoles = _rolesRepository.GetById(id);

            existingRoles.Name = rolesDto.Name;

            _rolesRepository.Update(existingRoles);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoles(int id)
        {
            try
            {
                _rolesRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }

        }
    }
}

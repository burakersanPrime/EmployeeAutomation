using em.Application.Interface;
using em.Domain.Entity;
using em.Domain.EntityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        [HttpGet]
        public List<Permission> GetPermissions()
        {
            var permissions = _permissionRepository.GetAll();
            return permissions;
        }

        [HttpGet("{id}")]
        public IActionResult GetPermission(int id)
        {
            var permission = _permissionRepository.GetById(id);
            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        [HttpPost]
        public IActionResult CreatePermission(PermissionDto permissionDto)
        {
            var permission = new Permission
            {
                employeeID = permissionDto.employeeID,
                startTime = permissionDto.startTime,
                endTime = permissionDto.endTime,
                reasonID = permissionDto.reasonID
            };

            _permissionRepository.Add(permission);
            return CreatedAtAction(nameof(GetPermission), new { id = permission.ID }, permission);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermission(int id, PermissionDto permissionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPermission = _permissionRepository.GetById(id);

            existingPermission.employeeID = permissionDto.employeeID;
            existingPermission.startTime = permissionDto.startTime;
            existingPermission.endTime = permissionDto.endTime;
            existingPermission.reasonID = permissionDto.reasonID;

            _permissionRepository.Update(existingPermission);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePermission(int id)
        {
            try
            {
                _permissionRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }

        }
    }
}

using em.Application.Interface;
using em.Domain.Entity;
using em.Domain.EntityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReasonController : ControllerBase
    {
        private readonly IReasonRepository _reasonRepository;

        public ReasonController(IReasonRepository reasonRepository)
        {
            _reasonRepository = reasonRepository;
        }

        [HttpGet]
        public List<Reason> GetReasons()
        {
            var reasons = _reasonRepository.GetAll();
            return reasons;
        }

        [HttpGet("{id}")]
        public IActionResult GetReason(int id)
        {
            var reason = _reasonRepository.GetById(id);
            if (reason == null)
                return NotFound();

            return Ok(reason);
        }

        [HttpPost]
        public IActionResult CreateReason(ReasonDto reasonDto)
        {
            var reason = new Reason
            {
                permissionReason = reasonDto.permissionReason,
            };

            _reasonRepository.Add(reason);
            return CreatedAtAction(nameof(GetReason), new { id = reason.ID }, reason);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReason(int id, ReasonDto reasonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingReason = _reasonRepository.GetById(id);

            existingReason.permissionReason = reasonDto.permissionReason;

            _reasonRepository.Update(existingReason);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReason(int id)
        {
            try
            {
                _reasonRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }

        }


    }
}

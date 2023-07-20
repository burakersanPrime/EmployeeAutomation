using Microsoft.AspNetCore.Mvc;
using em.Application.Interface;
using em.Domain.Entity;
using em.Domain.EntityDto;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return employees;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                Adress = employeeDto.Adress,
                CompanyID = employeeDto.CompanyID
            };

            _employeeRepository.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.ID }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEmployee = _employeeRepository.GetById(id);

            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Surname = employeeDto.Surname;
            existingEmployee.Adress = employeeDto.Adress;
            existingEmployee.CompanyID = employeeDto.CompanyID;

            _employeeRepository.Update(existingEmployee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }

        }

    }
}

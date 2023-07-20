using AutoMapper;
using em.Application.Interface;
using em.Domain.Entity;
using em.Domain.EntityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public List<Company> GetCompanies()
        {
            var companies = _companyRepository.GetAll();
            return companies;
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companyRepository.GetById(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyDto companyDto)
        {
            var company = new Company
            {
                Name = companyDto.Name,
                businessType = companyDto.businessType,
                Adress = companyDto.Adress
            };

            _companyRepository.Add(company);
            return CreatedAtAction(nameof(GetCompany), new { id = company.ID }, company);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCompany = _companyRepository.GetById(id);

            existingCompany.Name = companyDto.Name;
            existingCompany.businessType = companyDto.businessType;
            existingCompany.Adress = companyDto.Adress;

            _companyRepository.Update(existingCompany);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            try 
            {
                _companyRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using em.Persistence.Context;
using em.Application.Interface;
using System.Threading.Tasks;
using em.Domain.Entity;

namespace em.Application.Interface
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly conDBContext _context;
        public CompanyRepository(conDBContext context)
        {
            _context = context;
        }

        public Company GetById(int id)
        {
            return _context.Company.FirstOrDefault(c => c.ID == id);
        }

        public void Add(Company company)
        {
            company.createTime= DateTimeOffset.Now;
            _context.Company.Add(company);
            _context.SaveChanges();
        }

        public void Update(Company company)
        {
            company.updateTime = DateTimeOffset.Now;
            _context.Company.Update(company);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = _context.Company.FirstOrDefault(c => c.ID == id);
            company.updateTime = DateTimeOffset.Now;
            if (company != null)
            {
                company.deletedInfo = true;
                _context.SaveChanges();
            }
        }

        public List<Company> GetAll()
        {
            var t = _context.Company.ToList();
            return t;
        }
    }
}

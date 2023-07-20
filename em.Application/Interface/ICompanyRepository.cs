using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using em.Domain.Entity;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
        Company GetById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(int id);
    }
}

using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}

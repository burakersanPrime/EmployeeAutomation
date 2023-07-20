using em.Domain.Entity;
using em.Persistence.Context;
//using em.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly conDBContext _context;
        public EmployeeRepository(conDBContext context)
        {
            _context = context;
        }

        public Employee GetById(int id)
        {
            return _context.Employee.FirstOrDefault(e => e.ID == id);
        }

        public void Add(Employee employee)
        {
            employee.createTime = DateTimeOffset.UtcNow;
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            employee.updateTime = DateTimeOffset.Now;
            _context.Employee.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employee.FirstOrDefault(c => c.ID == id);
            employee.updateTime = DateTimeOffset.Now;
            if (employee != null)
            {
                employee.deletedInfo = true;
                _context.SaveChanges();
            }
        }

        public List<Employee> GetAll()
        {
            var t = _context.Employee.ToList();
            return t;
        }
    }
}

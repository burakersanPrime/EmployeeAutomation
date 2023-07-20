using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Domain.EntityDto
{
    public class EmployeeDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Adress { get; set; }
        public int? CompanyID { get; set; }
    }
}

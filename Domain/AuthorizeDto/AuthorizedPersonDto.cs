using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Domain.AuthorizeDto
{
    public class AuthorizedPersonDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int roleID { get; set; }
    }
}

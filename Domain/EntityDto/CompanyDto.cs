using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Domain.EntityDto
{
    [Table("Company")]
    public class CompanyDto
    {
        public string? Name { get; set; }
        public string? businessType { get; set; }
        public string? Adress { get; set; }
    }
}

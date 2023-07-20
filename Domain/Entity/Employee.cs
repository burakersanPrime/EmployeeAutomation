using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace em.Domain.Entity
{
    public class Employee
    {
        public Employee()
        {
            Permission = new HashSet<Permission>();
        }

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Adress { get; set; }
        public int? CompanyID { get; set; }
        public DateTimeOffset? createTime { get; set; }
        public DateTimeOffset? updateTime { get; set; }
        public bool? deletedInfo { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<Permission>? Permission { get; set; }
    }
}

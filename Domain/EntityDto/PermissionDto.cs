using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Domain.EntityDto
{
    public class PermissionDto
    {
        public int? employeeID { get; set; }
        public DateTimeOffset? startTime { get; set; }
        public DateTimeOffset? endTime { get; set; }
        public int? reasonID { get; set; }
    }
}

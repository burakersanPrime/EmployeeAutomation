using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace em.Domain.Entity
{
    public class Permission
    {
        public int ID { get; set; }
        public int? employeeID { get; set; }
        public DateTimeOffset? startTime { get; set; }
        public DateTimeOffset? endTime { get; set; }
        public int? reasonID { get; set; }
        public DateTimeOffset? createTime { get; set; }
        public DateTimeOffset? updateTime { get; set; }
        public bool? deletedInfo { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Reason? Reason { get; set; }
    }
}

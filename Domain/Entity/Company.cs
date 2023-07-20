using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace em.Domain.Entity
{
    [Table("Company")]
    public class Company
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? businessType { get; set; }
        public string? Adress { get; set; }
        public DateTimeOffset? createTime { get; set; }
        public DateTimeOffset? updateTime { get; set; }
        public bool? deletedInfo { get; set; }
    }
}

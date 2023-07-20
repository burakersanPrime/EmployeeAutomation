using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Domain.Authorize
{
    public class Roles
    {
        public Roles()
        {
            AuthorizedPerson = new HashSet<AuthorizedPerson>();
        }

        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? createTime { get; set; }
        public DateTimeOffset? updateTime { get; set; }
        public bool? deletedInfo { get; set; }
        public virtual ICollection<AuthorizedPerson>? AuthorizedPerson { get; set; }

    }
}

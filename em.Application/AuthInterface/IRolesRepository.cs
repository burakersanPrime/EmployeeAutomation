using em.Domain.Authorize;
using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.AuthInterface
{
    public interface IRolesRepository
    {
        List<Roles> GetAll();
        Roles GetById(int id);
        void Add(Roles roles);
        void Update(Roles roles);
        void Delete(int id);
    }
}

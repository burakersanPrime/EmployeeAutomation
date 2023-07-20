using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public interface IPermissionRepository
    {
        List<Permission> GetAll();
        Permission GetById(int id);
        void Add(Permission permission);
        void Update(Permission permission);
        void Delete(int id);
    }
}

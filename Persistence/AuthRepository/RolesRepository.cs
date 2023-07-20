using em.Domain.Entity;
using em.Persistence.Context;
using em.Domain.Authorize;
using em.Application.AuthInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace em.Persistence.AuthRepository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly conDBContext _context;
        public RolesRepository(conDBContext context)
        {
            _context = context;
        }

        public Roles GetById(int id)
        {
            return _context.Roles.FirstOrDefault(e => e.ID == id);
        }

        public void Add(Roles role)
        {
            role.createTime = DateTimeOffset.UtcNow;
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Update(Roles role)
        {
            role.updateTime = DateTimeOffset.Now;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var roles = _context.Roles.FirstOrDefault(c => c.ID == id);
            roles.updateTime = DateTimeOffset.Now;
            if (roles != null)
            {
                roles.deletedInfo = true;
                _context.SaveChanges();
            }
        }

        public List<Roles> GetAll()
        {
            var t = _context.Roles.ToList();
            return t;
        }
    }
}

using em.Domain.Entity;
using em.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly conDBContext _context;
        public PermissionRepository(conDBContext context)
        {
            _context = context;
        }

        public Permission GetById(int id)
        {
            return _context.Permission.FirstOrDefault(p => p.ID == id);
        }

        public void Add(Permission permission)
        {
            permission.createTime = DateTimeOffset.Now;
            _context.Permission.Add(permission);
            _context.SaveChanges();
        }

        public void Update(Permission permission)
        {
            permission.updateTime = DateTimeOffset.Now;
            _context.Permission.Update(permission);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var permission = _context.Permission.FirstOrDefault(c => c.ID == id);
            permission.updateTime = DateTimeOffset.Now;
            if (permission != null)
            {
                permission.deletedInfo = true;
                _context.SaveChanges();
            }
        }

        public List<Permission> GetAll()
        {
            var t = _context.Permission.ToList();
            return t;
        }

        public void Delete(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}

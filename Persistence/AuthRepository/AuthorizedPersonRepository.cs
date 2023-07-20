using em.Domain.Authorize;
using em.Domain.Entity;
using em.Persistence.Context;
using em.Application.AuthInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace em.Persistence.AuthRepository
{
    public class AuthorizedPersonRepository : IAuthorizedPersonRepository
    {
        private readonly conDBContext _context;
        public AuthorizedPersonRepository(conDBContext context)
        {
            _context = context;
        }

        public AuthorizedPerson GetById(int id)
        {
            return _context.AuthorizedPerson.FirstOrDefault(e => e.ID == id);
        }

        public void Add(AuthorizedPerson authorizedPerson)
        {
            authorizedPerson.createTime = DateTimeOffset.UtcNow;
            _context.AuthorizedPerson.Add(authorizedPerson);
            _context.SaveChanges();
        }

        public void Update(AuthorizedPerson authorizedPerson)
        {
            authorizedPerson.updateTime = DateTimeOffset.Now;
            _context.AuthorizedPerson.Update(authorizedPerson);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var authorizedPerson = _context.AuthorizedPerson.FirstOrDefault(c => c.ID == id);
            authorizedPerson.updateTime = DateTimeOffset.Now;
            if (authorizedPerson != null)
            {
                authorizedPerson.deletedInfo = true;
                _context.SaveChanges();
            }
        }

        public List<AuthorizedPerson> GetAll()
        {
            var t = _context.AuthorizedPerson.AsNoTracking().Include(x => x.roles).ToList();
            return t;
        }
    }
}

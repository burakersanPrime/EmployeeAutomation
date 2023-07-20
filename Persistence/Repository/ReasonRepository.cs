using em.Domain.Entity;
using em.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using em.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public class ReasonRepository : IReasonRepository
    {
        private readonly conDBContext _context;
        public ReasonRepository(conDBContext context)
        {
            _context = context;
        }

        public Reason GetById(int id)
        {
            return _context.Reason.FirstOrDefault(r => r.ID == id);
        }

        public void Add(Reason reason)
        {
            _context.Reason.Add(reason);
            _context.SaveChanges();
        }

        public void Update(Reason reason)
        {
            _context.Reason.Update(reason);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var reason = _context.Reason.FirstOrDefault(c => c.ID == id);
            if (reason != null)
            {
                reason.deletedInfo = true;
                _context.SaveChanges();
            }
        }

        public List<Reason> GetAll()
        {
            var t = _context.Reason.ToList();
            return t;
        }

        public void Delete(Reason reason)
        {
            throw new NotImplementedException();
        }
    }
}

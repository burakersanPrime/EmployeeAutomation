using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.Interface
{
    public interface IReasonRepository
    {
        List<Reason> GetAll();
        Reason GetById(int id);
        void Add(Reason reason);
        void Update(Reason reason);
        void Delete(int id);
    }
}

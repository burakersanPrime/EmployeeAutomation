using em.Domain.Authorize;
using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.AuthInterface
{
    public interface IAuthorizedPersonRepository
    {
        List<AuthorizedPerson> GetAll();
        AuthorizedPerson GetById(int id);
        void Add(AuthorizedPerson authorizedPerson);
        void Update(AuthorizedPerson authorizedPerson);
        void Delete(int id);
    }
}

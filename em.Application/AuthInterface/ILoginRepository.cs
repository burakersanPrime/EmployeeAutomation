using em.Domain.Authorize;
using em.Domain.AuthorizeDto;
using em.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em.Application.AuthInterface
{
    public interface ILoginRepository
    {
        AuthorizedPerson UserInfo(LoginRequestModel request);
        public string TokenContent(AuthorizedPerson user);
        public string Role(AuthorizedPerson user);
    }
}

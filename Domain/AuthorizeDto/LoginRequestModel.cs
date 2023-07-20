using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace em.Domain.AuthorizeDto
{
    public class LoginRequestModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }


        ////Ignore
        //[JsonIgnore]
        //public string? Name { get; set; }
        //[JsonIgnore]
        //public string? Surname { get; set; }
        //[JsonIgnore]
        //public int authorizationID { get; set; }
    }
}

using Azure.Core;
using em.Application.AuthInterface;
using em.Domain.Authorize;
using em.Domain.AuthorizeDto;
using em.Persistence.AuthRepository;
using em.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;

namespace EmployeeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, ILoginRepository loginRepository)
        {
            _configuration = configuration;
            _loginRepository = loginRepository;
        }

        //[HttpPost("register")]
        //public ActionResult<AuthorizedPersonAuthDto> Register(AuthorizedPersonAuthDto request)
        //{
        //    string password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        //    //AuthP.Username = request.Username;
        //    //AuthP.Password = password;
        //    return Ok(new AuthorizedPersonAuthDto()
        //    {

        //    });
        //}

        [HttpPost("login")]
        public ActionResult<string> Login(LoginRequestModel request)
        {
            var user = _loginRepository.UserInfo(request);
            if (user == null)
            {
                BadRequest("Wrong username or password");
            }
            string token = CreateToken(user);
            return Ok(token);
        }
        private string CreateToken(AuthorizedPerson user)
        {
            return _loginRepository.TokenContent(user);
        }

        private string JwtRole(AuthorizedPerson user)
        {
            return _loginRepository.Role(user);
        }
    }
}

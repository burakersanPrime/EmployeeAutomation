using em.Application.AuthInterface;
using em.Domain.Authorize;
using em.Domain.AuthorizeDto;
using em.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace em.Persistence.AuthRepository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly conDBContext _context;
        private readonly IConfiguration _configuration;
        public LoginRepository(conDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AuthorizedPerson UserInfo(LoginRequestModel request)
        {
            var user = _context.AuthorizedPerson.Include(x => x.roles)
                .Where(u => u.Username == request.Username && u.Password == request.Password)
                .FirstOrDefault();

            return user;
        }

        public string TokenContent(AuthorizedPerson user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.roles?.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string Role(AuthorizedPerson user)
        {
            string token = TokenContent(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // Token'ı çözümle
                var decodedToken = tokenHandler.ReadJwtToken(token);

                // Rol claim'ini al
                var role = decodedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

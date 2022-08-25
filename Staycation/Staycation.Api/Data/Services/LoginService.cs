using Microsoft.IdentityModel.Tokens;
using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Staycation.Api.Data.Services
{
    public class LoginService
    {
        private AccommodationContext _context;
        private IConfiguration _config;
        public LoginService(AccommodationContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User Authenticate(UserVM userVM)
        {
            var currentUser = _context.Users.Where(a => a.Email == userVM.Email).Where(a => a.Password == userVM.Password).SingleOrDefault();
            if (currentUser != null)
            {
                return currentUser;
            }
            else
            {
                throw new Exception("Wrong email or password!");
            }
        }
    }
}

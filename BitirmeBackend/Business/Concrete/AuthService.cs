using Business.Abstract;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private const string secret = "denemedenemedenemedenemedenemedenemedeneme";
        private IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public string generateToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(type:"userId",  value : user.Id.ToString()),
                new Claim(type:"role", value: user.UserType.ToString())
            };
            var token = new JwtSecurityToken("https://localhost:50198",
                "https://localhost:50198",
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
    }
}

using BookManagement.Entities;
using BookManagement.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BookManagement.BAL.Implementation
{
    public class UserManager : IUserManager
    {
        private IConfiguration _config;

        public UserManager(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJSONWebToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }

        public UserModel Login(UserModel userLoginModel)
        {
            using(var context = new BookManagementContext())
            {
                var IsUser = context.Users.FirstOrDefault(u => u.Email == userLoginModel.Email && u.Password == userLoginModel.Password);


                return new UserModel() { 
                    Id = IsUser.Id,
                    Username = IsUser.UserName,
                    Email = IsUser.Email
                };
            }
        }
    }
}

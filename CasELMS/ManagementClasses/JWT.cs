using CasELMS.DbClasses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CasELMS.ManagementClasses
{
    public class JWT
    {
        public static string GenerateJSONWebToken(StudentRegistration userInfo, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var claims = new[] {
            //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username) };

            var claims = new[] {
             new Claim("Email", userInfo.Email.ToString()),
             new Claim("Password", userInfo.Password.ToString())
            };


            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

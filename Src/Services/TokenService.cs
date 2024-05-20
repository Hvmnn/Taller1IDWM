using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Services;

public class TokenService (IConfiguration config) : ITokenService
{
    public string CreateToken(string rut, string nameRole)
    {
            var claims = new List<Claim>{
                new (ClaimTypes.Role, nameRole)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
    }

}
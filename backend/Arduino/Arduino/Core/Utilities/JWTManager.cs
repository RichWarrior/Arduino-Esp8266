using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Core.Utilities
{
    public static class JWTManager
    {
        public static string GenerateToken(User user)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ArduinoESP8266App"));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

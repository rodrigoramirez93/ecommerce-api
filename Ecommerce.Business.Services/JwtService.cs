using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Business.Services
{
    public class JwtService : IJwtService
    {
        private readonly Appsettings _appsettings;
        public JwtService(IOptionsSnapshot<Appsettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }

        public TokenDto GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettings.JwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_appsettings.JwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _appsettings.JwtSettings.Issuer,
                audience: _appsettings.JwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var idToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDto(idToken, expires);
        }
    }
}

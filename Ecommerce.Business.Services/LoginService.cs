using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public LoginService(UserManager<User> userManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<TokenDtoResponse> GetToken(SignInDto signInDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == signInDto.Email);

            if (user is null)
            {
                return new TokenDtoResponse(null, HttpStatusCode.NotFound);
            }

            var userPasswordIsValid = await _userManager.CheckPasswordAsync(user, signInDto.Password);

            if (userPasswordIsValid)
            {
                var baseClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var userClaims = await _userManager.GetClaimsAsync(user);
                var claims = baseClaims.Concat(userClaims).ToList();

                var token = _jwtService.GenerateJwt(user, claims);
                return new TokenDtoResponse(token, HttpStatusCode.OK);
            }

            return new TokenDtoResponse(null, HttpStatusCode.BadRequest);
        }
    }
}

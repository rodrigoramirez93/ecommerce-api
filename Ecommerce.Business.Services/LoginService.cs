using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                var roles = await _userManager.GetRolesAsync(user);
                var token = _jwtService.GenerateJwt(user, roles);
                return new TokenDtoResponse(token, HttpStatusCode.OK);
            }

            return new TokenDtoResponse(null, HttpStatusCode.BadRequest);
        }
    }
}

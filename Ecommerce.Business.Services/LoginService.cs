using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;

        public LoginService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IJwtService jwtService,
            IContextService contextService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _contextService = contextService;
            _mapper = mapper;
        }

        public async Task<TokenDtoResponse> GetToken(SignInDto signInDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == signInDto.Email);

            if (user is null)
            {
                return new TokenDtoResponse(null, HttpStatusCode.NotFound);
            }

            var userPasswordIsValid = await _userManager.CheckPasswordAsync(user, signInDto.Password);

            if (!userPasswordIsValid)
            {
                return new TokenDtoResponse(null, HttpStatusCode.BadRequest);
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var rolesNames = await _userManager.GetRolesAsync(user);
            var rolesIds = _roleManager.Roles.Where(role => rolesNames.Contains(role.Name)).Select(x => x.Id).ToList();
            var roleClaims = new List<RoleClaim>();

            _contextService.Do((context) =>
            {
                roleClaims = context.RoleClaims.Where(x => rolesIds.Contains(x.RoleId)).ToList();
            });
            
            var userClaims = roleClaims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue)).ToList();

            claims.AddRange(userClaims);

            var token = _jwtService.GenerateJwt(user, claims);
            return new TokenDtoResponse(token, HttpStatusCode.OK);
        }
    }
}

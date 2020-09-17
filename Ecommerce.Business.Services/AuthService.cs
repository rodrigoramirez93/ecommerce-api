using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{

    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly Appsettings _appsettings;
        private readonly IJwtService _jwtService;

        public AuthService(ILogger<AuthService> logger,
            UserManager<User> userManager,
            IMapper mapper,
            RoleManager<Role> roleManager,
            IOptionsSnapshot<Appsettings> appsettings,
            IJwtService jwtService)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _appsettings = appsettings.Value;
            _jwtService = jwtService;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDto signUpDto)
        {
            var user = _mapper.Map<SignUpDto, User>(signUpDto);
            return await _userManager.CreateAsync(user, signUpDto.Password);
        }

        public async Task<IdentityResult> AddUserToRoleAsync(string userEmail, string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);
            return await _userManager.AddToRoleAsync(user, roleName);
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
                var token =_jwtService.GenerateJwt(user, roles);
                return new TokenDtoResponse(token, HttpStatusCode.OK);
            }

            return new TokenDtoResponse(null, HttpStatusCode.BadRequest);
        }
    }
}

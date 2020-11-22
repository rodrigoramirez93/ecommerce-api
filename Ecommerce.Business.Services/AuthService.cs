//using AutoMapper;
//using Ecommerce.Business.Dto;
//using Ecommerce.Business.Services.Interfaces;
//using Ecommerce.Core;
//using Ecommerce.Domain.Model;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using System;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace Ecommerce.Business.Services
//{

//    public abstract class AuthService<U> : IAuthService<U>
//        where U: Role
//    {
//        private readonly ILogger<AuthService<U>> _logger;
//        private readonly IMapper _mapper;

//        private readonly UserManager<User> _userManager;
//        private readonly RoleManager<U> _roleManager;
//        private readonly IJwtService _jwtService;

//        private readonly Appsettings _appsettings;
        
//        public AuthService(ILogger<AuthService<U>> logger,
//            IMapper mapper,
//            UserManager<User> userManager,
//            RoleManager<U> roleManager,
//            IJwtService jwtService,
//            IOptionsSnapshot<Appsettings> appsettings)
//        {
//            _logger = logger;
//            _userManager = userManager;
//            _mapper = mapper;
//            _roleManager = roleManager;
//            _appsettings = appsettings.Value;
//            _jwtService = jwtService;
//        }

//        public virtual async Task<IdentityResult> CreateAsync(SignUpDto signUpDto)
//        {
//            var user = _mapper.Map<SignUpDto, User>(signUpDto);
//            return await _userManager.CreateAsync(user, signUpDto.Password);
//        }

//        public virtual async Task<IdentityResult> AddToRoleAsync(string userEmail)
//        {
//            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);
//            return await _userManager.AddToRoleAsync(user, roleName);
//        }
//    }
//}

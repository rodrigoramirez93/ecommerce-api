using AutoMapper;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services
{
    public class AdminAuthService : AuthService<User, Role>, IAdminAuthService
    {
        public AdminAuthService(ILogger<AuthService<User, Role>> logger,
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IJwtService jwtService,
            IOptionsSnapshot<Appsettings> appsettings) 
            : base(logger, mapper, userManager, roleManager, jwtService, appsettings)
        {

        }
    }
}

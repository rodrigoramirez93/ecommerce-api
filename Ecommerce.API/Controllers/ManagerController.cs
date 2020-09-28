using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerAuthService _authService;

        public ManagerController(IManagerAuthService authService)
        {
            _authService = authService;
        }

        //[AuthorizeRoles(Roles.Admin, Roles.Manager)]
        [HttpPost]
        public async Task<IActionResult> CreateManager(SignUpDto signUpDto)
        {
            var result = await _authService.CreateAsync(signUpDto);
            if (!result.Succeeded)
                return Problem(result.Errors.ToString());
            return Ok();
        }
    }
}

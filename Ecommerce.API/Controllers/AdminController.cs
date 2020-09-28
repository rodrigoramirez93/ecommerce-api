using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminAuthService _authService;

        public AdminController(IAdminAuthService authService)
        {
            _authService = authService;
        }

        [AuthorizeRoles(Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(SignUpDto signUpDto)
        {
            var result = await _authService.CreateAsync(signUpDto);
            if (!result.Succeeded)
                return Problem(result.Errors.ToString());
            return Ok();
        }
    }
}

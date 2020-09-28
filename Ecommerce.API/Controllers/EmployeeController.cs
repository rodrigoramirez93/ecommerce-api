using System.Threading.Tasks;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAuthService _authService;

        public EmployeeController(IEmployeeAuthService authService)
        {
            _authService = authService;
        }

        [AuthorizeRoles(Roles.Admin, Roles.Manager)]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(SignUpDto signUpDto)
        {
            var result = await _authService.CreateAsync(signUpDto);
            if (!result.Succeeded)
                return Problem(result.Errors.ToString());
            return Ok();
        }
    }
}

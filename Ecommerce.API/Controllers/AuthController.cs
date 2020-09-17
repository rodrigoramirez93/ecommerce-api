using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.API
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<ProductController> logger,
            IAuthService authService,
            IJwtService jwtService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var userCreateResult = await _authService.CreateUserAsync(signUpDto);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var result = await _authService.AddUserToRoleAsync(userEmail, roleName);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var response = await _authService.GetToken(signInDto);

            return response.HttpStatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest("Email or password incorrect."),
                HttpStatusCode.NotFound => NotFound("Username not found"),
                HttpStatusCode.OK => Ok(response),
                _ => BadRequest("Something went wrong"),
            };
        }
    }
}

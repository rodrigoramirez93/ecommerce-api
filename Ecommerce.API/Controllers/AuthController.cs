using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.API
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ILoginService _loginService;

        public AuthController(
            ILogger<ProductController> logger,
            ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var response = await _loginService.GetToken(signInDto);

            return response.HttpStatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest("Email or password incorrect."),
                HttpStatusCode.NotFound => NotFound("Username not found"),
                HttpStatusCode.OK => Ok(response.Token),
                _ => BadRequest("Something went wrong"),
            };
        }
    }
}

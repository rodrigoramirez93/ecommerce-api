using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.ExtensionMethods;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = Claims.CAN_READ_USERS)]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _userService.GetAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Claims.CAN_READ_USERS)]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Authorize(Policy = Claims.CAN_CREATE_USERS)]
        public async Task<IActionResult> Post(SignUpDto signUpDto)
        {
            var response = await _userService.CreateAsync(signUpDto);
            if (!response.Succeeded)
                return Problem(detail: response.Errors.ToProblemDescription(), statusCode: 400);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = Claims.CAN_UPDATE_USERS)]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Claims.CAN_DELETE_USERS)]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(
            ILogger<RoleController> logger,
            IRoleService roleService
            )
        {
            _logger = logger;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            return new OkObjectResult(await _roleService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            return new OkObjectResult(await _roleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
        {
            return new OkObjectResult(await _roleService.CreateAsync(roleDto));
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdateRole(string roleId, [FromBody] RoleDto roleDto)
        {
            return new OkObjectResult(await _roleService.UpdateAsync(roleId, roleDto));
        }

        [HttpPost("{roleId}/Claim")]
        public async Task<IActionResult> AddClaimToRole(string roleId, [FromBody] ClaimDto claimDto)
        {
            return new OkObjectResult(await _roleService.AddClaimToRoleAsync(roleId, claimDto));
        }


        [HttpDelete("{roleId}/Claim/")]
        public async Task<IActionResult> Delete(string roleId, ClaimDto claimDto)
        {
            return new OkObjectResult(await _roleService.RemoveClaimFromRoleAsync(roleId, claimDto));
        }
    }
}

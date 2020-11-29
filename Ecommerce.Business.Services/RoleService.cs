using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Business.Services.Queries;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }


        public async Task<IdentityResult> AddClaimToRoleAsync(string roleId, ClaimDto claimDto)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var claim = new Claim(claimDto.ClaimType, claimDto.ClaimValue);
            return await _roleManager.AddClaimAsync(role, claim);
        }

        public Task<IdentityResult> CreateAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            return _roleManager.CreateAsync(role);
        }

        public async Task<List<RoleDto>> GetAsync()
        {
            var roleDtoList = new List<RoleDto>();
            var roles = await _roleManager.Roles.ToListAsync();

            var userClaims = new List<Claim>();
            var tasks = roles.Select(async (role) => userClaims.AddRange((await _roleManager.GetClaimsAsync(role))));

            await Task.WhenAll(tasks);

            return null;
        }

        public async Task<RoleDto> GetByIdAsync(int roleId)
        {
            return _mapper.Map<RoleDto>(await _roleManager.Roles.Where(role => role.Id == roleId).FirstOrDefaultAsync());
        }

        public async Task<IdentityResult> RemoveClaimFromRoleAsync(string roleId, ClaimDto claimDto)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            role.MustExist(Messages.Error.NotFound("role"));
            var claims = await _roleManager.GetClaimsAsync(role);
            var claim = claims.Where(claim => claim.Type == claimDto.ClaimType && claim.Value == claimDto.ClaimValue).FirstOrDefault();
            claim.MustExist(Messages.Error.NotFound("claim"));
            return await _roleManager.RemoveClaimAsync(role, claim);
        }

        public async Task<IdentityResult> UpdateAsync(string roleId, RoleDto roleDto)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(roleId);
            roleToUpdate.Name = roleDto.Name;
            return await _roleManager.UpdateAsync(roleToUpdate);
        }
    }
}

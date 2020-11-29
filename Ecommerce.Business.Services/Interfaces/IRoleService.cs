using Ecommerce.Business.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAsync();
        Task<RoleDto> GetByIdAsync(int roleId);
        Task<IdentityResult> UpdateAsync(string roleId, RoleDto roleDto);
        Task<IdentityResult> CreateAsync(RoleDto roleDto);
        Task<IdentityResult> AddClaimToRoleAsync(string roleId, ClaimDto claimDto);
        Task<IdentityResult> RemoveClaimFromRoleAsync(string roleId, ClaimDto claimDto);
        
    }
}

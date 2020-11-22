using Ecommerce.Business.Dto;
using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IAuthService<U> 
        where U: Role
    {
        Task<IdentityResult> CreateAsync(SignUpDto signUpDto);
        Task<IdentityResult> AddToRoleAsync(string userEmail);
    }
}

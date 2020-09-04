using Ecommerce.Business.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(SignUpDto signUpDto);
        Task<IdentityResult> AddUserToRoleAsync(string userEmail, string roleName);
        Task<TokenDtoResponse> GetToken(SignInDto signUpDto);
    }
}

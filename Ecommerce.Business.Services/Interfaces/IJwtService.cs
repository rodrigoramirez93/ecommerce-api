using Ecommerce.Business.Dto;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IJwtService
    {
        TokenDto GenerateJwt(User user, List<Claim> claims);
    }
}

using Ecommerce.Business.Dto;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IJwtService
    {
        TokenDto GenerateJwt(User user, IList<string> roles);
    }
}

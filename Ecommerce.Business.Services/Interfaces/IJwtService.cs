using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(User user, IList<string> roles);
    }
}

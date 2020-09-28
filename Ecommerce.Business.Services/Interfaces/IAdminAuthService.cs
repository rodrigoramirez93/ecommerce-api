using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IAdminAuthService : IAuthService<User, Role>
    {
        
    }
}

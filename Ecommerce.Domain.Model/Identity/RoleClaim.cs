using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Domain.Model.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public string Description { get; set; }
    }
}

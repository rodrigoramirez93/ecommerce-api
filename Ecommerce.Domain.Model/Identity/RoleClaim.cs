using Ecommerce.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Domain.Model.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public string Description 
        {
            get 
            {
                Claims.All.TryGetValue(ClaimType, out string description);
                return description;
            }
            set { }
        }
    }
}

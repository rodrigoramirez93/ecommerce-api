using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Model.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual IList<UserRole> UsersRoles { get; set; }
    }
}

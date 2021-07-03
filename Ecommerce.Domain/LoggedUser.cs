using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Domain
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
        public IEnumerable<Claim> Tenants { get; set; }
    }
}

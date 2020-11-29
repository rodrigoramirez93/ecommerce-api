using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class RoleDto
    {
        public string Name { get; set; }
        public List<ClaimDto> Claims { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class ReadRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccessDto> Claims { get; set; }
    }

    public class UpdateRoleDto
    {
        public string Name { get; set; }
    }

    public class CreateRoleDto
    {
        public string Name { get; set; }
    }
}

using Ecommerce.Core;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class OrganizationDto : BaseDto
    {
        public int Name { get; set; }
        public List<User> Users { get; set; }
    }
}

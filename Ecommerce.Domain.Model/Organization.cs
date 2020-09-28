using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Model
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}

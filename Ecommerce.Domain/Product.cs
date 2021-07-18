﻿using Ecommerce.Core;
using Infrastructure.Models;

namespace Ecommerce.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int OrganizationId { get; set; }
    }
}

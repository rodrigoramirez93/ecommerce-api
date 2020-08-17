using Ecommerce.Core;
using System;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Model
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

    }
}

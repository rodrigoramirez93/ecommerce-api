using Ecommerce.Core;
using System;

namespace Ecommerce.Business.Dto
{
    public class ProductDto: BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}

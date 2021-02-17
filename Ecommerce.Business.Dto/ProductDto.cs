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

    public class UpdateProductDto : ProductDto
    {
        public int Id { get; set; }
    }

    public class ProductToCreateDto : ProductDto
    {

    }

    public class CreatedProductDto : ProductDto
    {
        public int Id { get; set; }
    }
}

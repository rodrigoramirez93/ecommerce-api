using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class ProductFilterDto: BaseSearchDto
    {
        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }
    }
}

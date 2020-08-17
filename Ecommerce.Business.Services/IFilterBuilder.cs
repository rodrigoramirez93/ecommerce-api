using Ecommerce.Business.Dto;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Business.Services
{
    public interface IFilterBuilder
    {
        Expression<Func<Product, bool>> Build(ProductFilterDto ProductFilterDto);
    }
}

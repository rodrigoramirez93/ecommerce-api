using Ecommerce.Business.Dto;
using Ecommerce.Domain.Model;
using LinqKit;
using System;
using System.Linq.Expressions;

namespace Ecommerce.Business.Services
{
    public class FilterBuilder : IFilterBuilder
    {
        public Expression<Func<Product, bool>> Build(ProductFilterDto ProductFilterDto)
        {
            var predicate = PredicateBuilder.New<Product>(true);

            if (!string.IsNullOrEmpty(ProductFilterDto.Name))
            {
                predicate = predicate.And(_ => _.Name.Contains(ProductFilterDto.Name));
            }

            if (ProductFilterDto.MinimumPrice != 0)
            {
                predicate = predicate.And(_ => _.Price > ProductFilterDto.MinimumPrice);
            }

            if (ProductFilterDto.MaximumPrice != 0)
            {
                predicate = predicate.And(_ => _.Price < ProductFilterDto.MaximumPrice);
            }

            return predicate;
        }
    }
}

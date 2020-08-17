using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(10);
            RuleFor(x => x.Description).MaximumLength(10);
            RuleFor(x => x.Price).LessThan(100);
            RuleFor(x => x.Stock).LessThan(10);
        }
    }
}

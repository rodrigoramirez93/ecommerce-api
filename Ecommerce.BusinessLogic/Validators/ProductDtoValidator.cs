using Ecommerce.Core;
using FluentValidation;
using Shared.Infrastructure.Core;
using static Shared.Infrastructure.Core.Constants;

namespace Ecommerce.BusinessLogic.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleSet(RuleSets.Create, () =>
            {
                RuleFor(_ => _.Name).MaximumLength(Validation.Max.Name);
                RuleFor(_ => _.Description).MaximumLength(Validation.Max.Description);
                RuleFor(_ => _.Price).LessThan(100);
                RuleFor(_ => _.Stock).LessThan(10);
            });
        }
    }
}

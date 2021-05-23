using Ecommerce.Core;
using FluentValidation;

namespace Ecommerce.BusinessLogic.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleSet(RuleSets.Create, () =>
            {
                RuleFor(_ => _.Name).MaximumLength(Constants.Validation.Max.Name);
                RuleFor(_ => _.Description).MaximumLength(Constants.Validation.Max.Description);
                RuleFor(_ => _.Price).LessThan(100);
                RuleFor(_ => _.Stock).LessThan(10);
            });
        }
    }
}

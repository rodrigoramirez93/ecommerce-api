using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services
{
    public class DtoValidator<T, U> : IDtoValidator<T, U> 
        where T : class 
        where U : class
    {
        public void Validate(U dto, params string[] ruleSet)
        {
            try
            {
                var validator = Activator.CreateInstance<T>() as AbstractValidator<U>;
                validator.Validate(dto, options => options.IncludeRuleSets(ruleSet).ThrowOnFailures());

            }
            catch (ValidationException validationException)
            {
                throw new Exception($"Validation failed: {validationException.Message}");
            }
        }

    }
}

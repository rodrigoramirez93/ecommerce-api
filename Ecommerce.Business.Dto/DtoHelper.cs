using Ecommerce.Core;
using FluentValidation;
using System;

namespace Ecommerce.Business.Dto
{
    public static class DtoHelper
    {
        public static void Validate<T,U>(U dto) 
            where T: class
            where U: BaseDto
        {
            try
            {
                var validator = Activator.CreateInstance<T>() as AbstractValidator<U>;
                validator.ValidateAndThrow(dto);
            }
            catch(ValidationException validationException)
            {
                throw new Exception($"Validation failed: {validationException.Message}");
            }
        }
    }
}

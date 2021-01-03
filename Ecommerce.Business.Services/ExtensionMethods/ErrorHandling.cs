using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Business.Services.ExtensionMethods
{
    public static class ErrorHandling
    {
        public static string ToProblemDescription(this IEnumerable<IdentityError> errors)
            => string.Join(',', errors.Select(error => error.Description));
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services.Queries
{
    public static class Common
    {
        public static T MustExist<T>(this T source, string exceptionMessage = "Entity doesn't exists") => source ?? throw new ArgumentNullException(exceptionMessage);
    }
}

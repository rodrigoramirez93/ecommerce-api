using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class Common
    {
        public static T MustExist<T>(this T source, string entity)
            => source ?? throw new AppException(Messages.Error.NotFound(entity));

        public static T MustExist<T>(this T source, string entity, object Id) 
            => source ?? throw new AppException(Messages.Error.NotFoundById(entity, Id.ToString()));

        public static T MustExist<T>(this T source, string entity, string propertyName, string propertyValue)
             => source ?? throw new AppException(Messages.Error.NotFoundByProperty(entity, propertyName, propertyValue));

    }
}

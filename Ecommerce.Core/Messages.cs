using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class Messages
    {
        public static class Error
        {
            public static string ContactAdministrator = $"Please contact your administrator.";
            public static string NotFound(string entity) => $"{char.ToUpper(entity[0]) + entity.Substring(1)} does not exist. {ContactAdministrator}";
            public static string NotFoundById(string entity, string id) => $"{char.ToUpper(entity[0]) + entity.Substring(1)} with Id {id} does not exist. {ContactAdministrator}";
            public static string NotFoundByProperty(string entity, string propertyName, string propertyValue) => $"There is no {char.ToUpper(entity[0]) + entity.Substring(1)} with {propertyName} = {propertyValue}. {ContactAdministrator}";
        }
    }
}

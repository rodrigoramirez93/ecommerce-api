using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Core
{
    public static class HelperMethods
    {
        public static List<string> GetNames(params Roles[] roles)
        {
            var result = new List<string>();

            roles.ToList().ForEach(role =>
            {
                result.Add(role.ToString());
            });

            return result;
        }
    }
}

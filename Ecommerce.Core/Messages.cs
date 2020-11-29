using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class Messages
    {
        public static class Error
        {
            public static string NotFound(string entity) => $"Entity {entity} does not exists"; 
        }
    }
}

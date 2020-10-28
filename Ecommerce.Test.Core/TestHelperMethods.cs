using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Test.Core
{
    public static class TestHelperMethods
    {
        public static IQueryable<Entity> ToQueryable<Entity>(this Entity instance)
        {
            return new[] { instance }.AsQueryable();
        }
    }
}

using System;

namespace Ecommerce.Test.Core
{
    public abstract class EntityAbstractFactory<T, U> 
        where T: class
        where U: Enum
    {
        public abstract T CreateInstance(U options);
    }
}

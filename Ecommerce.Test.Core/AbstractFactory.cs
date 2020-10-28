using Ecommerce.Core;
using System;

namespace Ecommerce.Test.Core
{
    public abstract class EntityAbstractFactory<T, U> 
        where T: BaseEntity
        where U: Enum
    {
        public abstract T CreateInstance(U options);
    }
}

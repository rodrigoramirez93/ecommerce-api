using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IDtoValidator<T,U>
        where T: class
        where U: class
    {
        void Validate(U dto, params string[] ruleSet);
    }
}

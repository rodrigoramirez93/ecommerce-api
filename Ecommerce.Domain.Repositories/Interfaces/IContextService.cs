using Ecommerce.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IContextService
    {
        public void Do(Action<DatabaseContext> action);
    }
}

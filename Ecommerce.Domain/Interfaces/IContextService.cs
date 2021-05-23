using System;

namespace Ecommerce.Domain.Interfaces
{
    public interface IContextService
    {
        public void Do(Action<DatabaseContext> action);
    }
}

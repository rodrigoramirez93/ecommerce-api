using Ecommerce.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.Domain
{
    public class ContextService : IContextService
    {
        internal IServiceScopeFactory _scopeFactory;

        public ContextService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Do(Action<DatabaseContext> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = (DatabaseContext)scope.ServiceProvider.GetService(typeof(DatabaseContext));
                {
                    action(context);
                }
            }
        }
    }
}

using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Repositories
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

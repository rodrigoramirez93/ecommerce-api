using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<int> Create(T entity);

        Task<T> ReadAsync(int id);

        Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> predicate);

        T Update(T entity);

        Task DeleteAsync(string entityName, int id);

        Task<IEnumerable<T>> ReadAsync();
    }
}

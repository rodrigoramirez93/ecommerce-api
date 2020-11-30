using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        int Create(T entity);

        T Read(int id);

        IEnumerable<T> Read();

        IEnumerable<T> Read(Expression<Func<T, bool>> predicate);

        T Update(T entity);

        void Delete(int id);
    }
}

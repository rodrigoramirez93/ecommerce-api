using Ecommerce.Core;
using System.Collections.Generic;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T entity);

        T Read(int id);

        IEnumerable<T> Read();

        T Update(T entity);

        T Delete(int id);
    }
}
